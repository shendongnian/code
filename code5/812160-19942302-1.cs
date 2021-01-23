    public class ReorderingEventsTests : ReactiveTest
    {
        [Test]
        public void ReorderingTest1()
        {
            var scheduler = new TestScheduler();
            var s1 = scheduler.CreateColdObservable(
                OnNext(100, 1),
                OnNext(200, 2),
                OnNext(400, 3),
                OnNext(500, 4));
            var s2 = scheduler.CreateColdObservable(
                OnNext(100, 1),
                OnNext(200, 3),
                OnNext(300, 2),
                OnNext(500, 4));
            var results = scheduler.CreateObserver<int>();
            s1.OrderedCollect(s2, i => i, 1, i => i + 1).Subscribe(results);
            scheduler.Start();
            results.Messages.AssertEqual(
                OnNext(100, 1),
                OnNext(300, 2),
                OnNext(400, 3),
                OnNext(500, 4));
        }
        [Test]
        public void ReorderingTest2()
        {
            var scheduler = new TestScheduler();
            var s1 = scheduler.CreateColdObservable(
                OnNext(100, 1),
                OnNext(200, 2),
                OnNext(300, 3),
                OnNext(400, 4));
            var s2 = scheduler.CreateColdObservable(
                OnNext(100, 4),
                OnNext(200, 3),
                OnNext(300, 2),
                OnNext(400, 1));
            var results = scheduler.CreateObserver<int>();
            s1.OrderedCollect(s2, i=>i,1,i => i + 1).Subscribe(results);
            scheduler.Start();
            results.Messages.AssertEqual(
                OnNext(400, 1),
                OnNext(400, 2),
                OnNext(400, 3),
                OnNext(400, 4));
        }
    }
