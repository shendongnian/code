    public event EventHandler TextChanged    <-----The Event name for the "CopyEvent" function
    {
        add
        {
            base.Events.AddHandler(EventText, value);
        }
        remove
        {
            base.Events.RemoveHandler(EventText, value);
        }
    }
