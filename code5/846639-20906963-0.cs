        var drvs = System.IO.DriveInfo.GetDrives();
        int hdcount = 0;
        List<string> drivenames = new List<string>();
        foreach (var drv in drvs)
        {
            if (drv.DriveType == System.IO.DriveType.Fixed)
            {
                drivenames.Add(drv.Name);
            }
        }
