        [Test]
        public void AKindOfTimeoutTest()
        {
            var scheduler = new TestScheduler();
            var clockStream = scheduler.CreateHotObservable(
                OnNext(100, Unit.Default),
                OnNext(200, Unit.Default),
                OnNext(300, Unit.Default),
                OnNext(400, Unit.Default),
                OnNext(500, Unit.Default),
                OnNext(600, Unit.Default),
                OnNext(750, Unit.Default), /* make clock funky! */
                OnNext(800, Unit.Default),
                OnNext(900, Unit.Default));
            var sourceStream = scheduler.CreateColdObservable(
                OnNext(50, 1),
                OnNext(150, 2),
                OnNext(250, 3),
                OnNext(275, 4),
                OnNext(400, 5),
                OnNext(900, 6));
            Func<int> timedOutSelector = () => 0;
            Func<int, int> okSelector = i => i;
            var results = scheduler.CreateObserver<int>();
            sourceStream.TimeoutDetector(clockStream, 3, timedOutSelector, okSelector)
                        .Subscribe(results);
            scheduler.Start();
            results.Messages.AssertEqual(
                OnNext(50, 1),
                OnNext(150, 2),
                OnNext(250, 3),
                OnNext(275, 4),
                OnNext(400, 5),
                OnNext(750, 0),
                OnNext(900, 6));
        }
    }
