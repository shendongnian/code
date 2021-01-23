    public string FavoriteColor
    {
       get
       {
          return this.favoriteColor;
       }
    
       set
       {
          if (value != this.favoriteColor)
          {
             this.favoriteColor = value;
             if (this.PropertyChanged != null)
             {
                this.PropertyChanged(this, new PropertyChangedEventArgs("FavoriteColor"));
                }
             }
       }
    }
