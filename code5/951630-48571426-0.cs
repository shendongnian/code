    private void BeforeItemMove(object Item, MAPIFolder MoveTo, ref bool Cancel)
    {
    	AppointmentItem appointment = (AppointmentItem)Item;
    
    	if(MoveTo == null || MoveTo.Name == "Deleted Items")
    	{
    		// Do something...
    	}
    
    	Marshal.ReleaseComObject(appointment);
    	appointment = null;
    }
