        private bool _isGestureCatched;
        private bool IsGestureCatched
        {
            get { return _isGestureCatched; }
            set
            {
                if (_isGestureCatched != value)
                {
                    if (!IsGestureCatched)
                    {
                        this._alreadyDone++;
                        this.RaisePropertyChanged(() => this.AlreadyDone);
                    }            
                }
                _isGestureCatched = value;
            }
        } 
