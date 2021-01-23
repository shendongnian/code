        public string Price {
            get { return this._price.ToString(); }
            set
            {
                if (value != null)
                {
                    decimal p;
                    if (decimal.TryParse(value, out p))
                    {
                        this._price = (value);
                        this.NotifyPropertyChanged("Price");
                    }
                }
            }
        }
