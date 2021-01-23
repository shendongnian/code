    protected void upnl_Load(object sender, EventArgs e)
    {
      if (ddlDialog1.SelectedItem.Value != "-1")
      {
        // Here ddlDialog1.SelectedValue is always " ", Even I get a data set of    values,ddlDialog2 is not populated with new values 
        ddlDialog2.DataSource = objMngr.GetData(ddlDialog1.SelectedValue);
        ddlDialog2.DataValueField = "Id";
        ddlDialog2.DataTextField = "name";
        ddlDialog2.DataBind();
      }
      
      upnl.Update();
    }
