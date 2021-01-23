        protected void Page_Load(object sender, EventArgs e)
       {
	    MyObject _class = new MyObject(HttpContext.Current);
	    _class.SetNameAndSurname();
	    Response.Write(Session("UserInfo").ToString);
       }
        private class MyObject
        {
	    public void SetNameAndSurname()
	    {
		    if ((this.Context.Session("UserInfo") == null)) {
			this.Context.Session.Add("UserInfo", this.Surname + "-" + this.Name);
		    } else {
			this.Context.Session("UserInfo") = this.Surname + "-" + this.Name;
		    }
	    }
	    private string _Name;
	    public string Name 
            {
		    get { return _Name; }
		    set { _Name = value; }
	    }
	    private string _Surname;
	    public string Surname
            {
		get { return _Surname; }
		set { _Surname = value; }
	    }
	    private HttpContext _context;
	    public HttpContext Context 
            {
		    get { return _context; }
		    set { _context = value; }
	    }
	    public MyObject(HttpContext Context)
	    {
		    this._context = Context;
	    }
	     public MyObject()
	     {
	     }
        }
