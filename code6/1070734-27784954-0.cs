        protected void Page_Load(object sender, EventArgs e)
        {
    
        if(!Page.IsPostBack)
    
         {
    
        DataTable dt = new DataTable(); 
        dt.Columns.Add(new DataColumn("Value", typeof(Int32)));
        dt.Columns.Add(new DataColumn("Text", typeof(String)));
    
        DataRow dr = dt.NewRow(); 
        dr[0] = 1;
        dr[1] = "Test of text";
        dt.Rows.Add(dr); 
    
        Test.DataSource = dt;
        Test.DataValueField = "Value";
        Test.DataTextField = "Text";
        Test.DataBind();
    
    
         }
    
    
        }
