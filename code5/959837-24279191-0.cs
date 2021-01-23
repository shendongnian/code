    System.IO.DriveInfo [] drives = System.IO.DriveInfo.GetDrives ();
    foreach (System.IO.DriveInfo drive in drives)
    {
      if (drive.DriveType == DriveType.Removable)
      {
        Console.WriteLine ("Found removable drive {0}", drive.Name);
      }
    }
