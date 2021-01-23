    protected void Page_Load(object sender, EventArgs e)        
        {
            //bind only the first time the page loads
            if (!IsPostBack)
            {                
                DataSet ds = GetData(sqlSel);
                if (ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("Unable to connect to the database.");
                }
            }
        }
        private DataSet GetData(string cmdSel)
        {
            //normally you should query the data from the DB
            //I've manually constructed a DataSet for simplification purposes
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ImageID", typeof(int)));
            dt.Columns.Add(new DataColumn("FileName", typeof(string)));
            dt.Columns.Add(new DataColumn("Score", typeof(int)));
            dt.Rows.Add(100, @"Images/beads.png", 0);
            dt.Rows.Add(200, @"Images/moreimages/scenary.jpeg", 3);
            dt.Rows.Add(300, @"Images/moreimages/scenary.jpeg", 5);
            ds.Tables.Add(dt);
            return ds;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //we are only interested in the data Rows
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow dataRow = (e.Row.DataItem as DataRowView).Row;
                //manually bind the Score column to the RadioButtonlist
                int? scoreId = dataRow["Score"] == DBNull.Value ? (int?)null : (int)dataRow["Score"];
                if (scoreId.HasValue)
                {
                    RadioButtonList test = e.Row.FindControl("test") as RadioButtonList;
                    test.ClearSelection();                    
                    test.SelectedValue = scoreId.Value.ToString();
                }
            }
        }
        protected void test_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList test = sender as RadioButtonList;
            GridViewRow gridRow = test.NamingContainer as GridViewRow;
            //obtain the current image Id
            int imageId = (int)GridView1.DataKeys[gridRow.RowIndex].Value;
            //obtain the current selection (we will take the first selected checkbox
            int selectedValue = int.Parse(test.SelectedValue);
            SaveToDB(imageId, selectedValue);
        }
        private void SaveToDB(int imageId, int selectedValue)
        {
            //call your SQL UPDATE code to save to database...
        }
