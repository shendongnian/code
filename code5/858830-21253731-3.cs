        string failureDir = string.Empty;
        failureDir = AppDomain.CurrentDomain.BaseDirectory + "Source\\";
        try
        {
            string failureDirToday = string.Empty;
            if(metaDataXmlPath.Contains("Country1"))
            {
                 string errorSourceName = "Country1";
                 failureDir = Path.Combine(Path.Combine(failureDir, errorSourceName), String.Format("{0} {1}", errorSourceName, todayMoveDate));
            }
            else if (metaDataXmlPath.Contains("Country2"))
            {
                 string errorSourceName = "Country2";
                 failureDir = Path.Combine(Path.Combine(failureDir, errorSourceName), String.Format("{0} {1}", errorSourceName, todayMoveDate));
            }
            else if (metaDataXmlPath.Contains("Country3"))
            {
                 string errorSourceName = "Country3";
                 failureDir = Path.Combine(Path.Combine(failureDir, errorSourceName), String.Format("{0} {1}", errorSourceName, todayMoveDate));
            }
            // Notice the eliminated line here
            // This is where we actually create the folder
            if (!Directory.Exists(failureDir))
                Directory.CreateDirectory(failureDir);
            // Notice the eliminated line here
        }
