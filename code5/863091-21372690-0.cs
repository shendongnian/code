    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int section = Convert.ToInt32(lstSectionNumber.SelectedValue);
            double ticketQuantity = Convert.ToInt32(txtNumberOfTickets.Text);
        }
        catch (FormatException ex)
        {
            // put an error message.
        }
    }
