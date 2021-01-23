        public string Server
        {
            get { return this._server; }
            set
            {
                if (this._server != value)
                {
                    this._server = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Server"));
                    }
                }
            }
        }
