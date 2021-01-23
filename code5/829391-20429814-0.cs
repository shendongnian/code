    public MyApplication(myEntities context = null)
                :base(context)
        {
            _1stApp = new 1stApplication(this._context);
            _2ndApp = new 2ndApplication(this._context);
            etc...
        }
    
    public BaseApplication(myEntities context)
            {
                if (context!=null)
                    _context = context;
                else
                    _context= new myEntities ();
            }
