    protected void Page_Load(object sender, EventArgs e)
    {
       
    
        if (!Page.IsPostBack)
        {
            
            Add.Click += (source, e1) =>
            {
                if(Session("count")==null)
                    Session("count")=1;
                Session("count") = CInt(Session("count")) + 1
                Response.Write(Session("count").ToString()); 
                
            };
        }
    
    }
