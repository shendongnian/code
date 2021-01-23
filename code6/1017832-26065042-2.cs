    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
    service.Credentials = new WebCredentials("bobsmith@yourdomain.onmicrosoft.com", "password");
    service.AutodiscoverUrl("bobsmith@yourdomain.onmicrosoft.com", RedirectionUrlValidationCallback);
    
    var folderView = new FolderView(100);   // or something like 100, idunno
    folderView.Traversal = FolderTraversal.Deep;
    folderView.PropertySet = new PropertySet(FolderSchema.FolderClass,FolderSchema.DisplayName, FolderSchema.TotalCount,FolderSchema.ParentFolderId);   // ... and/or whatever else you want to get - folderclass is important though. 
    
    FindFoldersResults folders = service.FindFolders(WellKnownFolderName.MsgFolderRoot, folderView);
    // Process each item.
    foreach (Folder myFolder in folders.Folders)
    {
    	if (myFolder is CalendarFolder)
    	{
    		var calendar = (myFolder as CalendarFolder);
    		// Initialize values for the start and end times, and the number of appointments to retrieve.
    		DateTime startDate = DateTime.Now;
    		DateTime endDate = startDate.AddDays(30);
    		const int NUM_APPTS = 15;
    		// Set the start and end time and number of appointments to retrieve.
    		CalendarView cView = new CalendarView(startDate, endDate, NUM_APPTS);
    		// Limit the properties returned to the appointment's subject, start time, and end time.
    		cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End);
    		// Retrieve a collection of appointments by using the calendar view.
    		FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
    		foreach (Appointment a in appointments)
    		{
    			Console.Write("Subject: " + a.Subject.ToString() + " ");
    			Console.Write("Start: " + a.Start.ToString() + " ");
    			Console.Write("End: " + a.End.ToString());
    			Console.WriteLine();
    		}
    	}
    }
