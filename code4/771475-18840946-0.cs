    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();
    
            switch (e.CommandName)
            {
                case "Insert":
                    GridViewRow fRow = gv.FooterRow;
                    dt.Columns.Add("id");
                    dt.Columns.Add("name");
                    dt = (DataTable)ViewState["students"];
                    DataRow dr = dt.NewRow();
                    TextBox txtnewid = (TextBox) fRow.FindControl("txtNewId");
                    TextBox txtnewName =  (TextBox) fRow.FindControl("txtNewName");
                    dr["id"] =  txtnewid.Text;
                    dr["name"] = txtnewName.Text ;
                    dt.Rows.Add(dr);
                    ViewState["students"] = dt;
                    gv.DataSource = ViewState["students"];
                    gv.DataBind();
                    break;
            }
        }
