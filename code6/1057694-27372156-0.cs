    protected void lnkSubject_CLick(object sender, EventArgs e)
    {
        Button Button2 = (Button)sender;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if (item.FindControl("Button2") != Button2)
            {
                Button otherButton = (Button)item.FindControl("Button2");
                otherButton.ForeColor = Color.Empty;
                otherButton.BackColor = Color.Empty;
                otherButton.BorderColor = Color.Empty;
            }
         }
         Button2.ForeColor = Color.Blue;
         Button2.BackColor = Color.White;
         Button2.BorderColor = Color.Blue;
    }
