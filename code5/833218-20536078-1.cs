    public className PropertyName
    {
       get{return this._PropertyName;}
       set
       {
          this._PropertyName = value;
          OnPropertyChanged("PropertyName");
       }
    }
    
    #region INotifyPropertyChanged Members
    
    public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Raises this object's PropertyChanged event.
            /// </summary>
            /// <param name="propertyName">The property that has a new value.</param>
            protected virtual void OnPropertyChanged(string propertyName)
            {    
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    var e = new PropertyChangedEventArgs(propertyName);
                    handler(this, e);
                }
            }
    
            #endregion
