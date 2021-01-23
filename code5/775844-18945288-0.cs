    class Song
    {
      prop IsSelected
      {
        get { return this.selected; }
        set { this.selected = value; PropertyChanged("IsSelected"); }
      }
    }
