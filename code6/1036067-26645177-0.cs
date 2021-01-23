    private object yourSelectedItem = new object();
    public object YourSelectedItem
    {
        get { return yourSelectedItem; }
        set
        {
             yourSelectedItem = value;
             CorrespondingEvent();
        }
    }
