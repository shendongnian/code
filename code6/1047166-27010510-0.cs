            get
            {
                return this._media;
            }
            set
            {
                if (this._media != value)
                {
                    this._media = value;
                    this.OnPropertyChanged("Media");
                }
            }
        }
        public void SetMedia(Uri baseUri, String path)
        {
           Media = new Uri(baseUri,path);
        }
