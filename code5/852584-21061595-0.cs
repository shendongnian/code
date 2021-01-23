    public void premiumTicketChanged (Object sender, EventArgs e)
    {
        int ticketCount = premiumticket.Where(c => c.Checked).Count;
        MessageBox.Show( string.Format("You have checked {0} checkboxes....", ticketCount));
    }
