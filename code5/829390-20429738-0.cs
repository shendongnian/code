    public MyApplication(myEntities context)
            :base(context)
    {
       _1stApp = new 1stApplication(this._context);
       _2ndApp = new 2ndApplication(this._context);
       etc...
    }
    public MyApplication()
        :this(new myEntities())
    { }
