    public bool IsOnline {
        get 
        {
            return ((Datetime.Now - UserIsOnlineTimeWindow) < LastActivityDate)
            //this is the behavior that the MembershipProvider uses by default
            //as you already mentioned in your question
        }
    }
