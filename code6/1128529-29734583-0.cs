    public sealed class FramerateScaler<T> : IEnumerable<T>
    {
        private IEnumerable<T> _source;
        private readonly double _inputRate;
        private readonly double _outputRate;
        private readonly int _startIndex;
        public double InputRate { get { return _inputRate; } }
        public double OutputRate { get { return _outputRate; } }
        public int StartIndex { get { return _startIndex; } }
        public TimeSpan InputDuration {
            get { return TimeSpan.FromSeconds((1 / _inputRate) * (_source.Count() - StartIndex)); }
        }
        public TimeSpan OutputDuration {
            get { return TimeSpan.FromSeconds((1 / _outputRate) * this.Count()); }
        }
        public FramerateScaler(
            double inputRate, double outputRate, 
            IEnumerable<T> source, int startIndex = 0)
        {
            _source = source;
            _inputRate = inputRate;
            _outputRate = outputRate;
            _startIndex = startIndex;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new ScalingFrameEnumerator<T>(_inputRate, _outputRate, _source, _startIndex);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        private sealed class ScalingFrameEnumerator<T> : IEnumerator<T>
        {
            internal readonly double _inputRate;
            internal readonly double _outputRate;
            internal readonly int _startIndex;
            private readonly List<T> _source;
            private readonly double _rateScaleFactor;
            private readonly int _totalOutputFrames;
            private int _currentOutputFrame = 0;
            public ScalingFrameEnumerator(
                double inputRate, double outputRate, 
                IEnumerable<T> source, int startIndex)
            {
                _inputRate = inputRate;
                _outputRate = outputRate;
                _source = source.ToList();
                _startIndex = startIndex;
                _rateScaleFactor = _outputRate / _inputRate;
                // Calculate total output frames from input duration
                _totalOutputFrames = (int)Math.Round(
                    (_source.Count - startIndex) * _rateScaleFactor, 0);
            }
            public T Current
            {
                get
                {
                    return _source[_startIndex + 
                        (int)Math.Ceiling(_currentOutputFrame / _rateScaleFactor) - 1];
                }
            }
            public void Dispose()
            {
                // Nothing unmanaged to dispose
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public bool MoveNext()
            {
                _currentOutputFrame++;
                return ((_currentOutputFrame - 1) < _totalOutputFrames);
            }
            public void Reset()
            {
                _currentOutputFrame = 0;
            }
        }
    }
