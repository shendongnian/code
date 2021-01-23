    public string SomeProperty { get { return _someProperty; }
        set
        {
            _someProperty = value;
            if(string.IsNullOrWhiteSpace(value))
                SetError("SomeProperty", "You must enter a value or something kthx");
            else
                ClearError("SomeProperty");
        } 
