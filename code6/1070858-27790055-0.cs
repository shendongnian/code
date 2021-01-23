    protected void Page_Load(object sender, EventArgs e)
    {
       var qs = Request.Querystring["view"];
       if(qs != null)
       {
          if(qs == "1")
          {
             MultiView1.ActiveViewIndex = 1;
          }
       }
    
    }
