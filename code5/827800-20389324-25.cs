    public class TestDistinct : ReactiveTest
    {
        [Test]
        public void DuplicateWithinDurationIsSupressed()
        {
            var scheduler = new TestScheduler();
            var source =scheduler.CreateColdObservable(
                OnNext(100, "a"),
                OnNext(200, "a"));
            var duration = TimeSpan.FromTicks(250);
            var results = scheduler.CreateObserver<string>();
            source.DistinctUntilChanged(duration, scheduler).Subscribe(results);
            scheduler.AdvanceBy(1000);
            results.Messages.AssertEqual(
                OnNext(100, "a"));
        }
        [Test]
        public void NonDuplicationWithinDurationIsNotSupressed()
        {
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(100, "a"),
                OnNext(200, "b"));
            var duration = TimeSpan.FromTicks(250);
            var results = scheduler.CreateObserver<string>();
            source.DistinctUntilChanged(duration, scheduler).Subscribe(results);
            scheduler.AdvanceBy(1000);
            results.Messages.AssertEqual(
                OnNext(100,"a"),
                OnNext(200,"b"));
        }
        [Test]
        public void DuplicateAfterDurationIsNotSupressed()
        {
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(100, "a"),
                OnNext(400, "a"));
            var duration = TimeSpan.FromTicks(250);
            var results = scheduler.CreateObserver<string>();
            source.DistinctUntilChanged(duration, scheduler).Subscribe(results);
            scheduler.AdvanceBy(1000);
            results.Messages.AssertEqual(
                OnNext(100, "a"),
                OnNext(400, "a"));
        }
        [Test]
        public void NonDuplicateAfterDurationIsNotSupressed()
        {
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(100, "a"),
                OnNext(400, "b"));
            var duration = TimeSpan.FromTicks(250);
            var results = scheduler.CreateObserver<string>();
            source.DistinctUntilChanged(duration, scheduler).Subscribe(results);
            scheduler.AdvanceBy(1000);
            results.Messages.AssertEqual(
                OnNext(100, "a"),
                OnNext(400, "b"));
        }
        [Test]
        public void TestWithSeveralValues()
        {
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(100, "a"),
                OnNext(200, "a"),
                OnNext(300, "b"),
                OnNext(350, "c"),
                OnNext(450, "b"),
                OnNext(900, "a"));
            var duration = TimeSpan.FromTicks(250);
            var results = scheduler.CreateObserver<string>();
            source.DistinctUntilChanged(duration, scheduler).Subscribe(results);
            scheduler.AdvanceBy(1000);
            results.Messages.AssertEqual(
                OnNext(100, "a"),
                OnNext(300, "b"),
                OnNext(350, "c"),
                OnNext(450, "b"),
                OnNext(900, "a"));
        }
        [Test]
        public void CanHandleNulls()
        {
            var scheduler = new TestScheduler();
            var source = scheduler.CreateColdObservable(
                OnNext(100, "a"),
                OnNext(400, (string)null),
                OnNext(500, "b"),
                OnNext(600, (string)null),
                OnNext(700, (string)null));
            var duration = TimeSpan.FromTicks(250);
            var results = scheduler.CreateObserver<string>();
            source.DistinctUntilChanged(duration, scheduler).Subscribe(results);
            scheduler.AdvanceBy(1000);
            results.Messages.AssertEqual(
                OnNext(100, "a"),
                OnNext(400, (string)null),
                OnNext(500, "b"),
                OnNext(700, (string)null));
        }
    }
