    public class StuckDetectorTests : ReactiveTest
    {
        [Test]
        public void FindSingleStuckItem()
        {
            var testScheduler = new TestScheduler();
            var xs = testScheduler.CreateColdObservable(
                OnNext(TimeSpan.FromMinutes(5).Ticks, MyInfo.Started("1")));
            var results = testScheduler.CreateObserver<MyInfo>();
            xs.StuckInfos(testScheduler).Subscribe(results);
            testScheduler.Start();
            results.Messages.AssertEqual(
                OnNext(TimeSpan.FromMinutes(35).Ticks, MyInfo.Started("1")));
        }
    }
