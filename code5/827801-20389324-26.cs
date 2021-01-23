        [Test]
        public void TestWithSeveralValuesVariation1()
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
                OnNext(900, "a"));
        }
