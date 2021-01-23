    private bool isEventAlreadyRegistered = false;
    private static readonly object verrou = new object();
    private System.EventHandler myEvent = delegate { };
    public event System.EventHandler MyEvent
    {
        add
        {
            if(!isEventAlreadyRegistered)
            {
                isEventAlreadyRegistered = true;
                lock(verrou)
                {
                    //Double check as multiple add can be made simultaneously
                    if(!isEventAlreadyRegistered)
                    {
                        rankingOnUpdated += value;
                    }
                }
            }
        }
        remove
        {
            myEvent -= value;
        }
    }
