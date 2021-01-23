    public YourDataType CurrentItem
    {
        get { return currentItem; }
        set
        {
            currentItem = value;
            NotifyPropertyChanged("CurrentItem");
            if (SaveCommand.CanExecute(null)) SaveCommand.Execute(null);
        }
    }
