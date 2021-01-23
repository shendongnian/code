    public void Workers_DoWork(object sender, DoWorkEventArgs e)
    {
    	var backgroundWorker = sender as BackgroundWorker;
    	GetIcon Icon = new GetIcon();
    	BitmapImage IconOfComputer = null;
    	List<DiscoveredComputer> NetworkedComputers = new List<DiscoveredComputer>();
    	DirectoryEntry Discover = new DirectoryEntry("WinNT://Workgroup");
    	BitmapImage On = Icon.LoadIcon(@"/Images/Icons/ComputerOn.ico");
    	BitmapImage Off = Icon.LoadIcon(@"/Images/Icons/ComputerOff.ico");
    	
    	while (!backgroundWorker.CancellationPending)
    	{
    		foreach (DirectoryEntry Node in Discover.Children)
    		{
    			try
    			{
    				if (Node.Properties.Count > 0)
    				{
    					IconOfComputer = On;
    				}
    			}
    			catch
    			{
    				IconOfComputer = Off;
    			}
    			if (Node.Name != "Schema") { NetworkedComputers.Add(new DiscoveredComputer { Image = IconOfComputer, ComputerName = Node.Name, MyToolTip = "Node Type = " + Node.SchemaEntry.Name }); }
    		}
            break;
    	}
    	if(backgroundWorker.CancellationPending)
    	{
    		e.Cancel = true;
    	}
    	else
    	{
    		e.Result = NetworkedComputers;
    	}
    }
