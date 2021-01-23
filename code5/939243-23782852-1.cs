    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string code = GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (ViewState["CurrentData"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentData"];
             dt.PrimaryKey = new DataColumn[] { dt.Columns["Code"] };
            
            dt.Rows.Find(code).Delete();
            ViewState["CurrentData"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }                       
    }
