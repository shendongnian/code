    public class CallDeltaYRangeInfo : INotifyPropertyChanged
    {
        private double _yMin;
        public double Ymin
        {
            [DebuggerStepThrough]
            get { return _yMin; }
            [DebuggerStepThrough]
            set
            {
                if (Math.Abs(value - _yMin) > 1e-6)
                {
                    _yMin = value;
                    OnPropertyChanged("Ymin");
                }
            }
        }
        private double _yMax;
        public double Ymax
        {
            [DebuggerStepThrough]
            get { return _yMax; }
            [DebuggerStepThrough]
            set
            {
                if (Math.Abs(value - _yMax) > 1e-6)
                {
                    _yMax = value;
                    OnPropertyChanged("Ymax");
                }
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
