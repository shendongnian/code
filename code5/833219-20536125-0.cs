    public className PropertyName
    {
        get { return this._PropertyName; }
        set 
        {
           this._PropertyName = value; 
           if(PropertyChanged != null)
           {
              PropertyChanged(this, new PropertyChangedEventArgs("PropertyName"));
           }
        }
    }
