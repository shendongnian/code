    protected void lnkSubject_CLick(object sender, EventArgs e)
    {
        Button Button2 = (Button)sender;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            Button otherButton = (Button)item.FindControl("Button2");
            if (otherButton.ForeColor != Color.Empty )
            {
                otherButton.ForeColor = Color.Empty;
                otherButton.BackColor = Color.Empty;
                otherButton.BorderColor = Color.Empty;
            }
         }
         Button2.ForeColor = Color.Blue;
         Button2.BackColor = Color.White;
         Button2.BorderColor = Color.Blue;
    }
