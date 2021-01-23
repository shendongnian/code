    protected void Button_Click(object sender, EventArgs e)
    {            
        MailMessage m = new MailMessage();
            
        foreach (ListItem item in ListBox1.Items)
	    {
            if (item.Selected)
		        m.To.Add(new MailAddress(item.Value));
	    }
    }
