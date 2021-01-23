    private bool _isGridVisible;
        public bool IsGridVisible
        {
            get { return this._isGridVisible; }
            set
            {
                if (value != this._isGridVisible)
                {
                    this._isGridVisible = value;
                    this.RaisePropertyChanged("IsGridVisible");
                }
            }
        }
