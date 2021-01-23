    public static void TIF(Document dc, SortedList<string, object> dcIndexes)
    {
        string str1 = dcIndexes["Document,name"].ToString();
        string str2 = dcIndexes["Document,age"].ToString();
        string str5 = dcIndexes["Document,status"].ToString();
        string str3 = Path.Combine(Config.OutputFolder, DateTime.Now.ToString("yyyyMMdd"));
        if (!Directory.Exists(str3))
            Directory.CreateDirectory(str3);
        // ********
        // find first available file name
        bool done = false;
        int sequence = 0;
        string str4;
        string baseName = str1 + "_" + str2 + "_" + str5;
        do
        {
            // change here ***
            string fname = baseName;
            if (sequence > 0)
                fname = fname + "_" + sequence.ToString();
            // end of change ***
            str4 = Path.Combine(str3, fname + ".tif");
            if (File.Exists(str4))
                ++sequence;
            else
                done = true;
        } while (!done);
        
        // str4 now contains the file name
        // ********
        DocumentHistory dh = (DocumentHistory) null;
        string sourceFileName = ServiceES.FromSE(dc, out dh);
        if (File.Exists(str4))
            File.Delete(str4);
        File.Move(sourceFileName, str4);
        PTrace.LogInformation("{0} - TIF - {1}", (object) dc.Title, (object) str4);
    }
