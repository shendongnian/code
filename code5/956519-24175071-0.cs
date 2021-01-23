        public bool BtnIsEnabled
        {
            get { return this._BtnIsEnabled; }
            set
            {
                this._BtnIsEnabled = value;
                base.OnPropertyChanged("BtnIsEnabled");
            }
        }
        private bool _BtnIsEnabled;
