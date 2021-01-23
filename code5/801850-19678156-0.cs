     public void NamesToDropdownList()
    {
            objhatcheryPL.type = ddltype.SelectedItem.Text;
            DataTable dtname = new DataTable();
            dtname = objhatcheryBAL.dtnames(objhatcheryPL);
            ddlname.DataTextField = "Name";
            ddlname.DataValueField = "Name";
            ddlname.DataSource = dtname;
            ddlname.DataBind();
            ddlname.Items.Add(new ListItem("--select--", "0"));
            ddlname.SelectedIndex = ddlname.Items.Count - 1;
     }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
       {
        if (ddltype.SelectedItem.Text != "--Select--")
        {
            NamesToDropdownList();
        }
       }
