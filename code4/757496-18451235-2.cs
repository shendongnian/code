        protected void gridview()
        {
            
            DataTable dt = new DataTable();            
            dt.Columns.Add("id");
            dt.Columns.Add("name");         
            for (int i = 0; i < 100; i++)
            {               
                dt.Rows.Add(i.ToString(),"v"+i.ToString());
            }
            GridView gridData = new GridView();
            gridData.ID = "test";
            gridData.AutoGenerateEditButton = true;
            gridData.RowEditing += (sender, e) => grid_RowEditing(dt, e, sender);
            gridData.DataSource = dt;
            gridData.DataBind();
            p.Controls.Add(gridData);
        }
        protected void grid_RowEditing(DataTable tbl, GridViewEditEventArgs e, object sender)
        {
            ((GridView)sender).EditIndex = e.NewEditIndex;
            // call your databinding method here
            ((GridView)sender).DataSource = tbl;
            ((GridView)sender).DataBind();
        }
