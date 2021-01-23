    private string _updatedText;
    public string UpdatedText
    {
      get
      {
          return _updatedText;
      }
      set
      {
          _updatedText= value;
          OnStaticPropertyChanged("UpdatedText")
      }
    }
