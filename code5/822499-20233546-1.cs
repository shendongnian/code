    try
    {
    	var peers = await PeerFinder.FindAllPeersAsync();
    
    	// Handle the result of the FindAllPeersAsync call
    }
    catch (Exception ex)
    {
    	if ((uint)ex.HResult == 0x8007048F)
    	{
    		MessageBox.Show("Bluetooth is turned off");
    	}
    }
