    public void premiumTicketChanged (Object sender, EventArgs e)
    {
        int ticketCount = premiumticket.Count(c => c.Checked);
        MessageBox.Show( string.Format("You have checked {0} checkboxes....", ticketCount));
    }
