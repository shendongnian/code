    CSVReader reader = new CSVReader(FileUpload1.PostedFile.InputStream);
    string[] headers = reader.GetCSVLine();
    DataTable dt = new DataTable();
    foreach (string strHeader in headers)
    {
        dt.Columns.Add(strHeader);
    }       
    
    string[] data;
    while ((data = reader.GetCSVLine()) != null)
    {
        dt.Rows.Add(data);
    }
       
