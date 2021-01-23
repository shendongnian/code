        var drvs = System.IO.DriveInfo.GetDrives();
        List<string> drivenames = new List<string>();
        foreach (var drv in drvs)
        {
            if (drv.DriveType == System.IO.DriveType.Fixed)
            {
                drivenames.Add(drv.Name);
            }
        }
