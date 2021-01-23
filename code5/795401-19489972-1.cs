            public bool RiskHighLowMedium
            {
                get { return _riskHighLowMedium; }
                set
                {
                        _riskHighLowMedium = value;
                        this.OnPropertyChanged("RiskHighLowMedium");
                        this.OnPropertyChanged("Background");
                }
            }
