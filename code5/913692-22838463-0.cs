    object Content
    {
        get
        {
            // Your code here.
        }
    }
    
    BaseCmd.Content
    {
        get
        {
            return this.Content;
        }
        set
        {
            throw new NotSupportedException();
        }
    }
