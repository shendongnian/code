        private DateTime _StartDateTo;
        public DateTime StartDateTo 
        { 
            get { return _StartDateTo; } 
            set 
            { 
                _StartDateTo = value;
                Filter();
                NotifyOfPropertyChange(() => StartDateTo);
            } 
        }
        private DateTime _EndDateTo;
        public DateTime EndDateTo
        { 
            get { return _EndDateTo; }
            set
            {
                _EndDateTo = value;
                Filter();
                NotifyOfPropertyChange(() => EndDateTo);
            }
        }
        private ObservableCollection<Quarterly> _QuarterlyInfo;
        public ObservableCollection<Quarterly> QuarterlyInfo
        {
            get { return _QuarterlyInfo; } 
            set 
            {
                _QuarterlyInfo = value;
                Filter();
                NotifyOfPropertyChange(() => QuarterlyInfo);
            }
        }
