            public int _AnalysisProgress { get; set; }
        public int AnalysisProgress
        {
            get { return _AnalysisProgress; }
            set
            {
                _AnalysisProgress = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AnalysisProgress"));
            }
        }
