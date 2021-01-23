    private string text;
    public string Text
    {
         get
         {
              return text;
         }
         set
         {
              text = value;
              OnPropertyChanged("Text");
         }
    }
