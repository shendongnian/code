    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int section = Convert.ToInt32(lstSectionNumber.SelectedValue);
    
        double ticketQuantity;
        if(!int.TryParse(txtNumberOfTickets.Text, out section))
        {
            //Some error handling here...like MessageBox.Show("Please enter a valid ticket quanity");
        }
        
        //Do you regular logic here...
    }
