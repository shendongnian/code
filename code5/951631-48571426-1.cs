    private void BeforeItemMove(object Item, MAPIFolder MoveTo, ref bool Cancel)
    {
    	AppointmentItem appointment = (AppointmentItem)Item;  
    	Folder deletedItemsFolder = 
    		(Folder)Application
    			.Session
    			.GetDefaultFolder(OlDefaultFolders.olFolderDeletedItems);
    	
    	
    	if(MoveTo == null || MoveTo.StoreID == deletedItemsFolder.StoreID)
    	{
    		// Do something...
    	}
    
    	Marshal.ReleaseComObject(deletedItemsFolder);
    	deletedItemsFolder = null;
    	
    	Marshal.ReleaseComObject(appointment);
    	appointment = null;
    }
