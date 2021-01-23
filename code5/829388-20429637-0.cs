    public MyApplication(myEntities context)
    		:this()
    {
    	// custom
    }
    
    public MyApplication()
    {
    	_1stApp = new 1stApplication(this._context);
    	_2ndApp = new 2ndApplication(this._context);
    	etc...
    }
