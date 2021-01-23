    public class AlarmTests : ReactiveTest
    {
        [Test]
        public void MultipleKeyMultipleSignalMultipleLevelTest()
        {
            var threshold1 = TimeSpan.FromTicks(300);
            var threshold2 = TimeSpan.FromTicks(800);
            var scheduler = new TestScheduler();
            var signals = scheduler.CreateHotObservable(
                OnNext(200, 1),
                OnNext(200, 2),
                OnNext(400, 1),
                OnNext(420, 2),
                OnNext(800, 1),
                OnNext(1000, 1),
                OnNext(1200, 1));
            Func<int, int> keySelector = i => i;
            Func<int, int, TimeSpan> thresholdSelector = (key, level) =>
            {
                if (level == 1) return threshold1;
                if (level == 2) return threshold2;
                return TimeSpan.MaxValue;
            };
            var results = scheduler.CreateObserver<Alarm<int>>();
            signals.AlarmSystem(
                keySelector,
                thresholdSelector,
                2,
                scheduler).Subscribe(results);
            scheduler.Start();
            results.Messages.AssertEqual(
                OnNext(700, new Alarm<int>(1, 1)),
                OnNext(720, new Alarm<int>(2, 1)),
                OnNext(1220, new Alarm<int>(2, 2)),
                OnNext(1500, new Alarm<int>(1, 1)),
                OnNext(2000, new Alarm<int>(1, 2)));
        }
        [Test]
        public void CheckAlarmIsSuppressed()
        {
            var threshold1 = TimeSpan.FromTicks(300);
            var threshold2 = TimeSpan.FromTicks(500);
            var scheduler = new TestScheduler();
            var signals = scheduler.CreateHotObservable(
                OnNext(200, 1),
                OnNext(400, 1),
                OnNext(600, 1));
            Func<int, int> keySelector = i => i;
            Func<int, int, TimeSpan> thresholdSelector = (signal, level) =>
            {
                if (level == 1) return threshold1;
                if (level == 2) return threshold2;
                return TimeSpan.MaxValue;
            };
            var results = scheduler.CreateObserver<Alarm<int>>();
            signals.AlarmSystem(
                keySelector,
                thresholdSelector,
                2,
                scheduler).Subscribe(results);
            scheduler.Start();
            results.Messages.AssertEqual(
                OnNext(900, new Alarm<int>(1, 1)),
                OnNext(1100, new Alarm<int>(1, 2)));
        }
    }
    public static class ObservableExtensions
    {
        /// <summary>
        /// Create an alarm system that detects signal gaps of length
        /// determined by a signal key and signals alarms of increasing severity.
        /// </summary>
        /// <typeparam name="TSignal">Type of the signal</typeparam>
        /// <typeparam name="TKey">Type of the signal key used for grouping, must implement Equals correctly</typeparam>
        /// <param name="signals">Input signal stream</param>
        /// <param name="keySelector">Function to select a key from a signal for grouping</param>
        /// <param name="thresholdSelector">Function to select a threshold for a given signal key and alarm level.
        /// Should return TimeSpan.MaxValue for levels above the highest level</param>
        /// <param name="levels">Number of alarm levels</param>
        /// <param name="scheduler">Scheduler use for throttling</param>
        /// <returns>A stream of alarms each of which contains the signal and alarm level</returns>
        public static IObservable<Alarm<TSignal>> AlarmSystem<TSignal, TKey>(
            this IObservable<TSignal> signals,
            Func<TSignal, TKey> keySelector,
            Func<TKey, int, TimeSpan> thresholdSelector,
            int levels,
            IScheduler scheduler)
        {
            var alarmSignals = signals.Select(signal => new Alarm<TSignal>(signal, 0))
                                      .Publish()
                                      .RefCount();
            for (int i = 0; i < levels; i++)
            {
                alarmSignals = alarmSignals.CreateAlarmSystemLevel(
                    keySelector, thresholdSelector, i + 1, scheduler);
            }
            return alarmSignals.Where(alarm => alarm.Level != 0);
        }
        private static IObservable<Alarm<TSignal>> CreateAlarmSystemLevel<TSignal, TKey>(
            this IObservable<Alarm<TSignal>> alarmSignals,
            Func<TSignal, TKey> keySelector,
            Func<TKey, int, TimeSpan> thresholdSelector,
            int level,
            IScheduler scheduler)
        {
            return alarmSignals
                .Where(alarmSignal => alarmSignal.Level == 0)
                .Select(alarmSignal => alarmSignal.Signal)
                .GroupByUntil(
                    keySelector,
                    grp => grp.Throttle(thresholdSelector(grp.Key, level), scheduler))
                .SelectMany(grp => grp.TakeLast(1).Select(signal => new Alarm<TSignal>(signal, level)))
                .Merge(alarmSignals);
        }
    }
    public class Alarm<TSignal> : IEquatable<Alarm<TSignal>>
    {
        public Alarm(TSignal signal, int level)
        {
            Signal = signal;
            Level = level;
        }
        public TSignal Signal { get; private set; }
        public int Level { get; private set; }
        private static bool Equals(Alarm<TSignal> x, Alarm<TSignal> y)
        {
            if (ReferenceEquals(x, null))
                return false;
            if (ReferenceEquals(y, null))
                return false;
            if (ReferenceEquals(x, y))
                return true;
            return x.Signal.Equals(y.Signal) && x.Level.Equals(y.Level);
        }
        // Equality implementation added to help with testing.
        public override bool Equals(object other)
        {
            return Equals(this, other as Alarm<TSignal>);
        }
        public override string ToString()
        {
            return string.Format("Signal: {0} Level: {1}", Signal, Level);
        }
        public bool Equals(Alarm<TSignal> other)
        {
            return Equals(this, other);
        }
        public static bool operator ==(Alarm<TSignal> x, Alarm<TSignal> y)
        {
            return Equals(x, y);
        }
        public static bool operator !=(Alarm<TSignal> x, Alarm<TSignal> y)
        {
            return !Equals(x, y);
        }
        public override int GetHashCode()
        {
            return ((Signal.GetHashCode()*37) ^ Level.GetHashCode()*329);
        }
    }
