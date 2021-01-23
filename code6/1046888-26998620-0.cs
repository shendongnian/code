    [CustomAction]
    public static ActionResult SpawnBrowseFolderDialog(Session session)
    {
    	session.Log("Started the SpawnBrowseFolderDialog custom action.");
    	try
    	{
    		Thread worker = new Thread(() =>
    		{
    			FolderBrowserDialog dialog = new FolderBrowserDialog();
    			dialog.Description = "Please select an installation directory to house core files and components.";
    			dialog.SelectedPath = session["INSTALLFOLDER"];
    			DialogResult result = dialog.ShowDialog();
    			session["INSTALLFOLDER"] = dialog.SelectedPath;
    		});
    		worker.SetApartmentState(ApartmentState.STA);
    		worker.Start();
    		worker.Join();
    	}
    	catch (Exception exception)
    	{
    		session.Log("Exception while trying to spawn the browse folder dialog. {0}", exception.ToString());
    	}
    	session.Log("Finished the SpawnBrowseFolderDialog custom action.");
    	return ActionResult.Success;
    }
