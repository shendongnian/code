    public className PropertyName
    {
       get{return this._PropertyName;}
       set
       {
          this._PropertyName = value;
          OnPropertyChanged("PropertyName");
       }
    }
