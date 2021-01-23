    [DataMember]
    public string datestring
    {
        get
        {
            return DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"); 
        }
        private set
        {
        }
    }
