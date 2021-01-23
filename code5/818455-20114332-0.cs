    private readonly object _eventRegisterationLock = new object();
    
    protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch(e.Action) 
        {
            case Add:
                // Background Operation
                lock(_eventRegisterationLock)
                {
                    // check if the collection still contains the item
                    // then register the event
                }
                break;
            case Remove:
                // Background Operation
                lock(_eventRegisterationLock)
                {
                    // check if the collection still contains the item
                    // then unregister the event
                }
                break;
        }
    }
