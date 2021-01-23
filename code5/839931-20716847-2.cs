    DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("State");
         }
        protected void Button1_Click(object sender, EventArgs e)
        {
            dt.Rows.Add("1", "Vignesh", "True");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label1_ModalPopupExtender.Show();
    
        }
