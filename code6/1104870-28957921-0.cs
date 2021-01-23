     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                bindGV();
            }
        }
    
    
       public void bindGV() {
    
            SqlDataAdapter dap = new SqlDataAdapter("YourSQlQuery ", cn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            DataTable myDt = ds.Tables[0];
            if (myDt.Rows.Count == 0)
            {
                myDt.Rows.Add(myDt.NewRow());
                GridView1.DataSource = myDt;
                GridView1.DataBind();
                GridView1.Rows[0].Visible = false;
            }
            else
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
