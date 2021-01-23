    public Dictionary<string, int> Rolls
    {
       get 
       {
           if(Session["Rolls"] == null) 
               return new Dictionary<string, int>();
           else
               return (Dictionary<string, int>)Session["Rolls"];
       }
       set
       {
          Session["Rolls"] = value;
       }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       // Now Accessing Rolls in page will be directly hitting Session.
       // and Get property will give New dictionary object with 0 record instead of null
       // Otherwise it will return Object already caste into dictionary object
       foreach (var entry in Rolls) 
       {
            
       }
       // We always can assign new Dictionary object in Session by
       Rolls = new Dictionary<string, int>(10); // for example dictionary with 10 items
    }
