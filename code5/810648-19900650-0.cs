    public string Month 
    { 
        get 
        { 
            return DateTime.Parse(PublishedDate).Month; 
        }
        set
        {       
            PublishedDate = ... // this would be a little more code, but you can also do it
        }
    }
