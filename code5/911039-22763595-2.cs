     //edit:    
         protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Selection", typeof(string));
                dt.Columns.Add("Names", typeof(string));
            }
            DropDownList ddlSelection = new DropDownList();
            ddlSelection.Items.Add(new ListItem("one"));
            ddlSelection.Items.Add(new ListItem("two"));
            for(int i= 0; i < 10; i++)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[1] = "dropdownlist"+i;
                dt.Rows.Add(NewRow);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                DropDownList ddlSelection = new DropDownList();
                ddlSelection.Items.Add(new ListItem("one"));
                ddlSelection.Items.Add(new ListItem("two"));
                r.Cells[0].Controls.Add(ddlSelection);
            }
        }
