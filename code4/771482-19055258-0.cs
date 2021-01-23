    protected void OnCmdInsertClick(object sender, EventArgs e)
    {
        //Grid's footer row
        var footerRow = gv.FooterRow;
        if(footerRow !=null)
        {
            //get your textbox instances
            var txtNewId = (TextBox) footerRow.FindControl("txtNewId");
            var txtNewName = (TextBox) footerRow.FindControl("txtNewName");
            // Check for null
            if(txtNewId !=null && txtNewName !=null)
            {
                var dt = (DataTable)ViewState["students"];
                DataRow dr = dt.NewRow();
                dr["id"] =  txtNewId.Text;
                dr["name"] = txtNewName.Text;
                dt.Rows.Add(dr);                
                ViewState["students"] = dt;
                gv.DataSource = ViewState["students"];
                gv.DataBind();
            }
         }
    }
