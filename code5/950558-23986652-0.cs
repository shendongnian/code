     SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnect"].ToString());
    
        SqlDataAdapter sqladp = new SqlDataAdapter();
    
        DataTable dt = new DataTable();
    
        DataTable dt1 = new DataTable();
    
        DataTable dt2 = new DataTable();
    
    
      protected void Page_Load(object sender, EventArgs e)
    
        {
    
            if (!IsPostBack)
    
            {
    
                DataSet ds=new DataSet ();
    
                ds = ddlist("Select * from UserDetails");
    
                Grid_viewprofile.DataSource = ds;
    
                Grid_viewprofile.DataBind();
    
            }
        }
    
        protected void Grid_viewprofile_RowCommand(object sender, GridViewCommandEventArgs e) 
    
        {
    
            if (e.CommandName == "Close")    
            {   
    
            //    Panel1.Visible = false; 
    
            }  
    
            if (e.CommandName == "Move")       
            {
    
                GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
    
                DropDownList lstuserName = (DropDownList)gvRow.FindControl("ddl_groub");
    
                Response.Write("Selected Value : " + lstuserName.SelectedValue + " " + "Selected Item : " + lstuserName.SelectedItem.Text);  
    
                
    
            }
    
        }  
    
    
        public  DataSet   ddlist(string Qry)
    
        {
    
            DataSet ds = new DataSet();
    
            SqlDataAdapter sqladp = new SqlDataAdapter(Qry, sqlcon);
    
            sqladp.Fill(ds);
    
            return ds;
    
        }
    
        protected void Grid_viewprofile_RowDataBound(object sender, GridViewRowEventArgs e)
    
        {
    
            if (e.Row.RowType == DataControlRowType.DataRow)
    
            {
    
                DropDownList  ddl = (DropDownList)e.Row.FindControl("ddl_groub");
    
                ddl.DataSource = ddlist("Select * from UserDetails");
    
                ddl.DataTextField = "UserName";
    
                ddl.DataValueField = "ID";
    
                ddl.DataBind();
    
                ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    
            } 
    
        }
    }
