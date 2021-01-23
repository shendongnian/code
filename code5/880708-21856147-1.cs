      public string String1
      {
          //get should be here
          set
         {
           _string1 = value;
           OnPropertyChanged("IsButtonEnabled");
           OnPropertyChanged("String1");
          }
      }
