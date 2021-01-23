    private bool isChecked;
    public bool IsChecked
    {
       get { return isChecked; }
       set
       {
           if(isChecked != value)
           {
              isChecked = value;
              // Call OnPropertyChanged whenever the property is updated
              OnPropertyChanged("PersonName");
           }
        }
    }
