    protected void grdTenant_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdTenant.SelectedRow;
        lblRPCode.Text  = row.Cells[1].Text;
        lblRP.Text   = row.Cells[2].Text;
        lblType.Text = row.Cells[3].Text;
        lblBusiness.Text  = row.Cells[4].Text;
    
        //new ListItem with Text and Value of cells[5] gets inserted into ddl
        ddlRPGroup.Items.Insert(0, new ListItem(row.Cells[5].Text,row.Cells[5].Text));
        ddlRPGroup.SelectedValue = row.Cells[5].Text;
    }
