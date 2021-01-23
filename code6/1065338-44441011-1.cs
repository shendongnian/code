    //Somewhere in the begging of your class, in a place whose name I do not care to remember ...
    //Declare logger type
    private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
    
    public List<string> VolumenLabels()
    {
        //Return the List<T>
        List<string> myVolumeLabels = new List<string>();
        //Getting the info
        DriveInfo[] allDrives = DriveInfo.GetDrives();
            
        foreach(DriveInfo drive in allDrives)
        {
            if (drive.IsReady == true)
            {
                myVolumeLabels.Add(drive.VolumeLabel.ToString());
            }
            else
            {
                _log.Info("Check the Drive: " + drive.Name + " the device is not ready.");
            }
        }    
        return myVolumeLabels;
    }
