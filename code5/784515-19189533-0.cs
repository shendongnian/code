       protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                if(Request.QueryString["key"]!=null)
                {
                     DropDownListTime.SelectedValue= QueryString["key"];
                }
    
                BindData();
    
            }              
        }
