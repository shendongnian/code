    adp.Fill(DSOne, "Folder");
    if(DSOne.Tables[0].Rows.Count > 0)
    {
        // Here you are sure that the first table of the dataset contains at least one record.
        // So you could retrieve it (Rows[0]) and then access the first column 
        // of that row (Rows[0]["Folder"])
        string p = DSOne.Tables[0].Rows[0]["Folder"].ToString();
        string args = string.Format("/e, /select, \"{0}\"", p);
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "explorer";
        info.Arguments = args;
        Process.Start(info);     
    }
