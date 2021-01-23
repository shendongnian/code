    public class LapTimer : IDisposable
    {
        private readonly System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();
        private readonly ConcurrentDictionary<string, List<TimeSpan>> _carLapTimes = new ConcurrentDictionary<string, List<TimeSpan>>();
        private readonly Action<TimeSpan> _countdownReportingDelegate;
        private readonly TimeSpan _countdownReportingInterval;
        private System.Threading.Timer _countDownTimer;
        private TimeSpan _countdownTo = TimeSpan.FromSeconds(5);
        public LapTimer(TimeSpan countdownReportingInterval, Action<TimeSpan> countdownReporter)
        {
            _countdownReportingInterval = countdownReportingInterval;
            _countdownReportingDelegate = countdownReporter;
        }
        public void StartRace(TimeSpan countdownTo)
        {
            _carLapTimes.Clear();
            _stopWatch.Restart();
            _countdownTo = countdownTo;
            _countDownTimer = new System.Threading.Timer(this.CountdownTimerCallback, null, _countdownReportingInterval, _countdownReportingInterval);
        }
        public void RaceComplete()
        {
            _stopWatch.Stop();
            _countDownTimer.Dispose();
            _countDownTimer = null;
        }
        public void CarCompletedLap(string carId)
        {
            var elapsed = _stopWatch.Elapsed;
            _carLapTimes.AddOrUpdate(carId, new List<TimeSpan>(new[] { elapsed }), (k, list) => { list.Add(elapsed); return list; });
        }
        public IEnumerable<TimeSpan> GetLapTimesForCar(string carId)
        {
            List<TimeSpan> lapTimes = null;
            if (_carLapTimes.TryGetValue(carId, out lapTimes))
            {
                yield return lapTimes[0];
                for (int i = 1; i < lapTimes.Count; i++)
                    yield return lapTimes[i] - lapTimes[i - 1];
            }
            yield break;
        }
        private void CountdownTimerCallback(object state)
        {
            if (_countdownReportingDelegate != null)
                _countdownReportingDelegate(_countdownTo - _stopWatch.Elapsed);
        }
        public void Dispose()
        {
            if (_countDownTimer != null)
            {
                _countDownTimer.Dispose();
                _countDownTimer = null;
            }
        }
    }
    class Program
    {
        public static void Main(params string[] args)
        {
            using (var lapTimer = new LapTimer(TimeSpan.FromMilliseconds(100), remaining => Console.WriteLine(remaining)))
            {
                lapTimer.StartRace(TimeSpan.FromSeconds(5));
                System.Threading.Thread.Sleep(2000);
                lapTimer.RaceComplete();
            }
            Console.ReadLine();
        }
    }
