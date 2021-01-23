    public Room SelectedRoom
    {
        get { return selectedRoom; }
        set 
        {
            selectedRoom = value; 
            NotifyPropertyChanged("SelectedRoom"); 
            // Calculate new values here
        }
    }
