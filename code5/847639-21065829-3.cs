    private Collection<Type> availableItems;
    public Collection<Type> AvailableItems
        {
            get { return availableItems; }
            set
            {
                if (value != availableItems)
                {
                    availableItems = value;
                    OnPropertyChanged();
                }
            } 
        }
