    public class ConfigInfo
    {
        private class IntervalHolder
        {
            public static readonly IntervalHolder Empty = new IntervalHolder();
            private readonly int _factor1;
            private readonly int _factor2;
            private readonly int _interval;
            private IntervalHolder()
            {
            }
            private IntervalHolder(int factor1, int factor2)
            {
                _factor1 = factor1;
                _factor2 = factor2;
                _interval = _factor1*_factor2;
            }
            public IntervalHolder WithFactor1(int factor1)
            {
                return new IntervalHolder(factor1, _factor2);
            }
            public IntervalHolder WithFactor2(int factor2)
            {
                return new IntervalHolder(_factor1, factor2);
            }
            public int Factor1
            {
                get { return _factor1; }
            }
            public int Factor2
            {
                get { return _factor2; }
            }
            public int Interval
            {
                get { return _interval; }
            }
            public override bool Equals(object obj)
            {
                var otherHolder = obj as IntervalHolder;
                return 
                    otherHolder != null &&
                    otherHolder._factor1 == _factor1 &&
                    otherHolder._factor2 == _factor2;
            }
        }
        private IntervalHolder _intervalHolder = IntervalHolder.Empty;
        public int TimerInterval
        {
            get { return _intervalHolder.Interval; }
        }
        private void UpdateHolder(Func<IntervalHolder, IntervalHolder> update)
        {
            IntervalHolder oldValue, newValue;
            do
            {
                oldValue = _intervalHolder;
                newValue = update(oldValue);
            } while (!oldValue.Equals(Interlocked.CompareExchange(ref _intervalHolder, newValue, oldValue)));
        }
        public int Factor1
        {
            set { UpdateHolder(holder => holder.WithFactor1(value)); }
            get { return _intervalHolder.Factor1; }
        }
        public int Factor2
        {
            set { UpdateHolder(holder => holder.WithFactor2(value)); }
            get { return _intervalHolder.Factor2; }
        }
    }
