	public double CalcTicketCost(int section, double quantity)
	{
		double amount = 0;
		
		if (int.Parse(lstSectionNumber.SelectedItem.Value) < 150)
		{
			amount = premiumTicket * quantity;
		}
		else if (int.Parse(lstSectionNumber.SelectedItem.Value) > 150)
		{
			amount = basicTicket * quantity; 
		}
		
		return amount;
	}
