    private void executeButton_Click(object sender, EventArgs e)
    {
        UCClientType1  uc =frm.panel1.Controls.FindControl("uc1",true) as UCClientType1;
        if(uc1 != null)
        warning.Text = uc1.Name;
    }
  
