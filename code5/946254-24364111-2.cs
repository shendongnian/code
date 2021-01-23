    [TestFixture]
    public class DwellTriggerTests : ReactiveTest
    {
        //Need a predicate to break the fence. Maybe we actually want to know how long we have been within the fence?
        //  Scan-> home cord, start time, current duration
        //
        public IObservable<double> Query(IObservable<Point> coords, IScheduler scheduler)
        {
            return coords.Scan(
                    new Dweller(),
                    (acc, cur) => acc.CreateNext(cur, scheduler.Now))
                .Select(dweller => dweller.Percentage)
                .DistinctUntilChanged()
                .Where(percentage => percentage > 0.0);
        }
        [Test]
        public void Trigger_10Percent_after_100ms_of_mouse_position_within_fence()
        {
            //Assuming the fence is fixed from the first position, and isn't constantly reevaluated for each new position
            var testScheduler = new TestScheduler();
            var observer = testScheduler.CreateObserver<double>();
            var coords = testScheduler.CreateColdObservable(
                OnNext(020.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(040.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(060.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(080.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(100.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(120.Milliseconds(), new Point { X = 100, Y = 100 })
                );
            Query(coords, testScheduler).Subscribe(observer);
            testScheduler.Start();
            observer.Messages.AssertEqual(
                OnNext(120.Milliseconds(), 0.1)
                );
        }
        [Test]
        public void Trigger_20Percent_after_200ms_of_mouse_position_within_fence()
        {
            //Assuming the fence is fixed from the first position, and isn't constantly reevaluated for each new position
            var testScheduler = new TestScheduler();
            var observer = testScheduler.CreateObserver<double>();
            var coords = testScheduler.CreateColdObservable(
                OnNext(020.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(120.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(220.Milliseconds(), new Point { X = 100, Y = 100 })
                );
            Query(coords, testScheduler).Subscribe(observer);
            testScheduler.Start();
            observer.Messages.AssertEqual(
                OnNext(120.Milliseconds(), 0.1),
                OnNext(220.Milliseconds(), 0.2)
                );
        }
        [Test]
        public void Trigger_100Percent_after_1000ms_of_mouse_position_within_fence()
        {
            //Assuming the fence is fixed from the first position, and isn't constantly reevaluated for each new position
            var testScheduler = new TestScheduler();
            var observer = testScheduler.CreateObserver<double>();
            var coords = testScheduler.CreateColdObservable(
                OnNext(020.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(220.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(420.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(620.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(820.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(1020.Milliseconds(), new Point { X = 100, Y = 100 })
                );
            Query(coords, testScheduler).Subscribe(observer);
            testScheduler.Start();
            observer.Messages.AssertEqual(
                OnNext(220.Milliseconds(), 0.2),
                OnNext(420.Milliseconds(), 0.4),
                OnNext(620.Milliseconds(), 0.6),
                OnNext(820.Milliseconds(), 0.8),
                OnNext(1020.Milliseconds(), 1.0)
                );
        }
        [Test]
        public void Reset_after_sequence_hits_100Percent()
        {
            //Assuming the fence is fixed from the first position, and isn't constantly reevaluated for each new position
            var testScheduler = new TestScheduler();
            var observer = testScheduler.CreateObserver<double>();
            var coords = testScheduler.CreateColdObservable(
                OnNext(020.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(220.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(420.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(620.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(820.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(1020.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(1120.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(1220.Milliseconds(), new Point { X = 100, Y = 100 })
                );
            Query(coords, testScheduler).Subscribe(observer);
            testScheduler.Start();
            observer.Messages.AssertEqual(
                OnNext(220.Milliseconds(), 0.2),
                OnNext(420.Milliseconds(), 0.4),
                OnNext(620.Milliseconds(), 0.6),
                OnNext(820.Milliseconds(), 0.8),
                OnNext(1020.Milliseconds(), 1.0),
                OnNext(1220.Milliseconds(), 0.1)
                );
        }
        [Test]
        public void Reset_if_period_of_500ms_of_silence_occurs()
        {
            //Assuming the fence is fixed from the first position, and isn't constantly reevaluated for each new position
            var testScheduler = new TestScheduler();
            var observer = testScheduler.CreateObserver<double>();
            var coords = testScheduler.CreateColdObservable(
                OnNext(020.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(120.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(621.Milliseconds(), new Point { X = 100, Y = 100 }),
                OnNext(721.Milliseconds(), new Point { X = 100, Y = 100 })
                );
            Query(coords, testScheduler).Subscribe(observer);
            testScheduler.Start();
            observer.Messages.AssertEqual(
                OnNext(120.Milliseconds(), 0.1),
                OnNext(721.Milliseconds(), 0.1)
                );
        }
    }
    public static class TestExtentions
    {
        public static long Milliseconds(this int input)
        {
            return TimeSpan.FromMilliseconds(input).Ticks;
        }
        public static long Seconds(this int input)
        {
            return TimeSpan.FromSeconds(input).Ticks;
        }
    }
