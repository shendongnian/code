    DataTable csvData = new DataTable();
    csvData.Columns.Add("Date", typeof(string));
    csvData.Columns.Add("Value", typeof(double));
    string dir = @"C:\Main\test.csv"; 
    using (StreamReader sr = new StreamReader(dir))
    {
          string line = string.Empty;
          while ((line = sr.ReadLine()) != null)
          {
             DataRow dr = csvData.NewRow();
             string[] strRow = line.Split(',');
             dr["Date"] = strRow[0];
             dr["Value"] = strRow[1];
             csvData.Rows.Add(dr);
          }
    }
