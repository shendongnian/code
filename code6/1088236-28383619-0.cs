        private bool? _mutualChb;
        public bool? MutualChb
        {
            get { return (_mutualChb != null ) ?  _mutualChb: false; }
            set { 
                    _mutualChb = value;               
                    OnPropertyChanged("MutualChb"); 
                }
        }
