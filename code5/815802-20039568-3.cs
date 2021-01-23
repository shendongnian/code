    [TestClass]
    public class ThrottleMaxTests : ReactiveTest
    {
        [TestMethod]
        public void CanThrottle()
        {
            var scheduler = new TestScheduler();
            var results = scheduler.CreateObserver<int>();
            var source = scheduler.CreateColdObservable(
                OnNext(100, 1)
                );
            var dueTime = TimeSpan.FromTicks(100);
            var maxTime = TimeSpan.FromTicks(250);
            source.ThrottleMax(dueTime, maxTime, scheduler)
                .Subscribe(results);
            scheduler.AdvanceTo(1000);
            results.Messages.AssertEqual(
                OnNext(200, 1)
                );
        }
        [TestMethod]
        public void CanThrottleWithMaximumInterval()
        {
            var scheduler = new TestScheduler();
            var results = scheduler.CreateObserver<int>();
            var source = scheduler.CreateColdObservable(
                OnNext(100, 1),
                OnNext(175, 2),
                OnNext(250, 3),
                OnNext(325, 4),
                OnNext(400, 5)
                );
            var dueTime = TimeSpan.FromTicks(100);
            var maxTime = TimeSpan.FromTicks(250);
            source.ThrottleMax(dueTime, maxTime, scheduler)
                .Subscribe(results);
            scheduler.AdvanceTo(1000);
            results.Messages.AssertEqual(
                OnNext(350, 4),
                OnNext(500, 5)
                );
        }
    }
