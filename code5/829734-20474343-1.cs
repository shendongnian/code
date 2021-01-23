    private string lastName = string.Empty;
    public string LastName {
      get { return lastName; }
      set {
        if (value != lastName) {
          lastName = value;
          OnPropertyChanged("LastName");
        }
      }
    }
