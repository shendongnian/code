    LV_Tickets.EditIndex = e.NewEditIndex;
    LV_Tickets.DataBind();
    e.Cancel = true;
    TextBox JobDesTextBox = (TextBox)(LV_Tickets.EditItem.FindControl("JobDescTextBox"));
    JobDesTextBox.Text = "Setting the textbox";    
