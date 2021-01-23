    var gb = Math.Pow(1024, 3);
    foreach(var drive in DriveInfo.GetDrives())
    {	
    	if(drive.IsReady)
    	{
    	    Console.WriteLine("Drive {0} - Has free space of {1:n2} GB",
    	        drive.Name,
                drive.TotalFreeSpace / gb);
    	}
    }
