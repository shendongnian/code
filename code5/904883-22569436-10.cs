     private string _myProp = GetValueFromMethod();
     public MyProp
     {
        get { return _myProp; }
        set { _myProp = IsNullOrEmpty(value) ? GetValueFromMethod() : value; }
     }
