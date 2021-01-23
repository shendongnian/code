        public int _AnalysisProgress;
    public int AnalysisProgress
    {
        get { return _AnalysisProgress; }
        set
        {
            _AnalysisProgress = value;
            NotifyPropertyChanged("AnalysisProgress");
        }
    }
