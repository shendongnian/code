    LinkButton lkBtn = new LinkButton();
    lkBtn.ForeColor = Color.Black;
    lkBtn.Font.Underline = false;
    lkBtn.ID = "link_button" + i;
    lkBtn.Text = clientids;
    lkBtn.CommandName = "Edit";
    lkBtn.Click +=button_Click;
    
