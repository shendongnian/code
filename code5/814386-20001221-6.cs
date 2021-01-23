    public static partial class ObservableExtensions
    {
        public static IObservable<IList<TSource>> BufferNearEvents<TSource>(
            this IObservable<TSource> source,
            TimeSpan maxInterval,
            int maxBufferSize,
            IScheduler scheduler)
        {
            if (scheduler == null) scheduler = ThreadPoolScheduler.Instance;
            if (maxBufferSize <= 0)
                throw new ArgumentOutOfRangeException(
                    "maxBufferSize", "maxBufferSize must be positive");
            var publishedSource = source.Publish().RefCount();
            return publishedSource.Buffer(
                () => publishedSource
                    .Throttle(maxInterval, scheduler)
                    .Merge(publishedSource.Take(maxBufferSize).LastAsync()));
        }
    }
    public class BufferNearEventsTests : ReactiveTest
    {
        [Test]
        public void CloseEventsAreBuffered()
        {
            TimeSpan maxInterval = TimeSpan.FromTicks(200);
            const int maxBufferSize = 1000;
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(100, 1),
                OnNext(200, 2),
                OnNext(300, 3));
            IList<int> expectedBuffer = new [] {1, 2, 3};
            var expectedTime = maxInterval.Ticks + 300;
            var results = scheduler.CreateObserver<IList<int>>();
            source.BufferNearEvents(maxInterval, maxBufferSize, scheduler)
                  .Subscribe(results);
            scheduler.AdvanceTo(1000);
            results.Messages.AssertEqual(
                OnNext<IList<int>>(expectedTime, buffer => CheckBuffer(expectedBuffer, buffer)));
        }
        [Test]
        public void FarEventsAreUnbuffered()
        {
            TimeSpan maxInterval = TimeSpan.FromTicks(200);
            const int maxBufferSize = 1000;
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(1000, 1),
                OnNext(2000, 2),
                OnNext(3000, 3));
            IList<int>[] expectedBuffers =
            {
                new[] {1},
                new[] {2},
                new[] {3}
            };
            var expectedTimes = new[]
            {
                maxInterval.Ticks + 1000,
                maxInterval.Ticks + 2000,
                maxInterval.Ticks + 3000
            };  
            var results = scheduler.CreateObserver<IList<int>>();
            source.BufferNearEvents(maxInterval, maxBufferSize, scheduler)
                  .Subscribe(results);
            scheduler.AdvanceTo(10000);
            results.Messages.AssertEqual(
                OnNext<IList<int>>(expectedTimes[0], buffer => CheckBuffer(expectedBuffers[0], buffer)),
                OnNext<IList<int>>(expectedTimes[1], buffer => CheckBuffer(expectedBuffers[1], buffer)),
                OnNext<IList<int>>(expectedTimes[2], buffer => CheckBuffer(expectedBuffers[2], buffer)));
        }
        [Test]
        public void UpToMaxEventsAreBuffered()
        {
            TimeSpan maxInterval = TimeSpan.FromTicks(200);
            const int maxBufferSize = 2;
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(100, 1),
                OnNext(200, 2),
                OnNext(300, 3));
            IList<int>[] expectedBuffers =
            {
                new[] {1,2},
                new[] {3}
            };
            var expectedTimes = new[]
            {
                200, /* Buffer cap reached */
                maxInterval.Ticks + 300
            };
            var results = scheduler.CreateObserver<IList<int>>();
            source.BufferNearEvents(maxInterval, maxBufferSize, scheduler)
                  .Subscribe(results);
            scheduler.AdvanceTo(10000);
            results.Messages.AssertEqual(
                OnNext<IList<int>>(expectedTimes[0], buffer => CheckBuffer(expectedBuffers[0], buffer)),
                OnNext<IList<int>>(expectedTimes[1], buffer => CheckBuffer(expectedBuffers[1], buffer)));
        }
        private static bool CheckBuffer<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            CollectionAssert.AreEquivalent(expected, actual);
            return true;
        }
    }
