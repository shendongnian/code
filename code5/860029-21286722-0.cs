    public bool IsPopupOpen
    {
        get { return isPopupOpen; }
        set
        {
            isPopupOpen = value;
            NotifyPropertyChanged("IsPopupOpen");
            if (isPopupOpen)
            {
                // Do something in response to the opened popup here
            }
        }
    }
