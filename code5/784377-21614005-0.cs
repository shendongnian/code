    if (!Page.IsPostBack)
            {
    
                if (Request.QueryString["page"] != null)
                {
    
                    int index = int.Parse(Request.QueryString["page"]);
                    GridView1.PageIndex = index;
                    BindData();
    
    
                }
                else
                {
    
                    BindData();
    
                }
    
            }
