        private Visibility _showDetailsVideo = Visibility.Collapsed;
        public Visibility ShowDetailsVideo 
        { 
            get
            {
                return this._showDetailsVideo;
            }
            set
            {
                SetProperty(ref this._showDetailsVideo, value);
                this._showDetailsVideo = value;
                this.ShowMainScreen = value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        private Visibility _showMainScreen = Visibility.Visible;
        /// <summary>
        /// Never set this property, instead set ShowDetailsVideo instead.
        /// </summary>
        public Visibility ShowMainScreen
        {
            get
            {
                return this._showMainScreen;
            }
            private set
            {
                SetProperty(ref this._showMainScreen, value);
                this._showMainScreen = value;
            }
        }
