    using (System.IO.FileStream fs = new System.IO.FileStream("C:\\Somelocation\\report.xls", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
    {
        byte[] data = Properties.Resources.report;
        fs.Write(data, 0, data.Length);
    }
