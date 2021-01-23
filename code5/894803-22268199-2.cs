    adp.Fill(DSOne, "Folder");
    if(DSOne.Tables[0].Rows.Count > 0)
    {
        string p = DSOne.Tables[0].Rows[0]["Folder"].ToString();
        string args = string.Format("/e, /select, \"{0}\"", p);
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "explorer";
        info.Arguments = args;
        Process.Start(info);     
    }
