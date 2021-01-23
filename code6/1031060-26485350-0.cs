    private DateTime selectedTime
    {
        get { return (DateTime) GetValue(SelectedTimeProperty); }
        set { SetValue(SelectedTimeProperty, value); }
    }
    
    public DataTime SelectedTime
    {
        get { return selectedTime; }
        set
        {
            selectedTime = value;
            intendedDay = selectedTime.Day;
        }
    }
