        protected void gridview()
        {               
            GridView gridData = new GridView();
            gridData.ID = "test";
            gridData.AutoGenerateEditButton = true;
            
            gridData.RowEditing += (sender, e) => grid_RowEditing(SqlDataSource1, e, sender);
            gridData.DataSource = SqlDataSource1;
            gridData.DataBind();
            p.Controls.Add(gridData);
        }
        protected void grid_RowEditing(SqlDataSource tbl, GridViewEditEventArgs e, object sender)
        {
            ((GridView)sender).EditIndex = e.NewEditIndex;
            // call your databinding method here
            ((GridView)sender).DataSource = tbl;
            ((GridView)sender).DataBind();
        }
