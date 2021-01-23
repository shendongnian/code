    string eventTitle;
    public string EventTitle
    {
        get
        { 
            return eventTitle;
        }
        set
        {
            if(!IsNullOrWhiteSpace(value))
                eventTitle = value;
            else
                throw new MyEventException("Title cannot be empty.");
        }
    }
