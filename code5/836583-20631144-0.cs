     protected void Page_Load(object sender, EventArgs e)
        {
             DataTable table = (DataTable)Session["userTable"];
             string compare = Request.QueryString["id"].ToString();
             IEnumerable<DataRow> data = from x in table.AsEnumerable()
                           where x.Field<string>("Userid") == compare
                           select x; 
              
            DataTable boundTable = data.CopyToDataTable<DataRow>();
            GridView1.DataSource = boundTable;
                GridView1.DataBind();
        
         }
