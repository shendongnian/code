    public string Age
    {
       get { return _age; }
       set 
       {
            if (value > MyConfiguration.MaxValue)
               _age = MyConfiguration.MaxValue;
            else
               _age = value;
        }
    }
