    public class MovingAverageCalculator
    {
        public MovingAverageCalculator(int period)
        {
            _period = period;
            _window = new double[period];
            _stamps = new DateTime[period];
        }
        public double Average
        {
            get { return _average; }
        }
        public double StandardDeviation
        {
            get
            {
                var variance = Variance;
                if (variance >= double.Epsilon)
                {
                    var sd = Math.Sqrt(variance);
                    return double.IsNaN(sd) ? 0.0 : sd;
                }
                return 0.0;
            }
        }
        public double Variance
        {
            get
            {
                var n = N;
                return n > 1 ? _variance_sum / (n - 1) : 0.0;
            }
        }
        public bool HasFullPeriod
        {
            get { return _num_added >= _period; }
        }
        public IEnumerable<double> Observations
        {
            get { return _window.Take(N); }
        }
        public IEnumerable<DateTime> TimeStamps
        {
            get { return _stamps.Take(N); }
        }
        public int N
        {
            get { return Math.Min(_num_added, _period); }
        }
        public int WindowSize
        {
            get { return _window.Length; }
        }
        public bool IsOutOfBounds(double observation, double maxSDDeviation)
        {
            var dev = maxSDDeviation * StandardDeviation;
            return observation < _average - dev || observation > _average + dev;
        }
        public void Clear()
        {
            _num_added = 0;
            _average = 0;
            _variance_sum = 0;
        }
        public void AddObservation(DateTime stamp, double observation)
        {
            // Window is treated as a circular buffer.
            var ndx = _num_added % _period;
            var old = _window[ndx];     // get value to remove from window
            _window[ndx] = observation; // add new observation in its place.
            _stamps[ndx] = stamp;
            _num_added++;
            // Update average and standard deviation using deltas
            var old_avg = _average;
            if (_num_added <= _period)
            {
                var delta = observation - old_avg;
                _average += delta / _num_added;
                _variance_sum += (delta * (observation - _average));
            }
            else // use delta vs removed observation.
            {
                var delta = observation - old;
                _average += delta / _period;
                _variance_sum += (delta * ((observation - _average) + (old - old_avg)));
            }
        }
        private readonly int _period;
        private double[] _window;
        private DateTime[] _stamps;
        private int _num_added;
        private double _average;
        private double _variance_sum;
    }
