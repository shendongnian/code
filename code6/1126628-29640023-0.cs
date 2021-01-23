        private string _displayTitle;
        public String DisplayTitle
        {
            get
            {
                return _displayTitle;
            }
            set
            {
                if (value.Equals(_displayTitle)) return;
                _displayTitle = value;
                NotifyOfPropertyChange(() => DisplayName);
            }
        }
