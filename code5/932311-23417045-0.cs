    protected void btnOrderTickets_Click(object sender, EventArgs e)
    {
    	int numberOfTickets, ticketCost, eventId;
    	if(Int32.TryParse(txtNumberOfTickets.Text, out numberOfTickets) &&
    		Int32.TryParse(txtTotalCost.Text.TrimStart('$'), out ticketCost) &&
    		Int32.TryParse(txtEventID.Text, out eventId))
    	{
    		DateTime dt = Convert.ToDateTime(Session["date"]);
    		
    		TicketsDataAccessDataContext NewOrder = new TicketsDataAccessDataContext();
    		int returnedValue = NewOrder.PlaceOrderFull(eventId, txtEventDescription.Text, dt, Session["State"].ToString(), Session["section"].ToString(), Session["Row"].ToString(), numberOfTickets, ticketCost, "vfateev");
    		if (returnedValue != 0)
    		{
    			lblOutput.Text = "Error has occured. Please try again";
    			lblOutput.Visible = true;
    			btnOrderTickets.Visible = false;
    		}
    		else
    		{
    			lblOutput.Visible = true;
    			lblOutput.Text = "Thank you";
    			btnOrderTickets.Visible = false;
    		}
    	}
    	else
    	{
    		lblOutput.Visible = true;
    		lblOutput.Text = "Some validation error message here...";
    	}
    }
