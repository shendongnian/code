    public Brush StateColour
        {
            get { return this._StateColour; }
            set { this._StateColour = value; 
                  OnPropertyChanged("StateColour");
                }
        }
