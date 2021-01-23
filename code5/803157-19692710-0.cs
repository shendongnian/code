    try
    {
        DriveInfo[] ListDrives = DriveInfo.GetDrives();
         foreach (DriveInfo Drive in ListDrives)
         {
              if(!Drive.IsReady)//spin
        
              if(Drive.DriveType == DriveType.Removable)
              {
                   // double check it's valid and copy over stuff
              }
         }
    }
    catch(IOException ex)//...
