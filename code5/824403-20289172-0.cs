    public BaseClass()
    {
        Type actualType = this.GetType(); 
        if(actualType == typeof(ChildClass))
        {
            // we are the child class
        }
        else
        {
            // we are not...
        }
    }
