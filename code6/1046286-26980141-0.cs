    private object _obj;
    public object Obj 
    {
       get { return _obj ?? (_obj = new object()); }
       set { _obj = value; }
    }
