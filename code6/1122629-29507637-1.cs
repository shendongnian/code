    public class MyClass : INotifyPropertyChanged
    {
      private string _wordlist;
      private string _searchBox;
      public string WordList
      {
        get
        {
          return _wordlist;
        }
        set
        {
          _wordlist = value;
          RaisePropertyChanged("WordList");
        }
      }
      public string searchBox
      {
        get
        {
          return _searchBox;
        }
        set
        {
          _searchBox= value;
          RaisePropertyChanged("searchBox");
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      private void RaisePropertyChanged(string propertyName)
      {
        if(PropertyChanged != null)
          PropertyChanged(this, propertyName);
      }
    }
