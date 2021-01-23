    var sb = new StringBuilder();
    foreach (DataRow row in dt.Rows)
    {
        List<string> CsvList = new List<string>();
        foreach (var item in row.ItemArray)
        {
            CsvList.Add(item.ToString());
        }
        if (i == 1)
        {
            CsvList.Add(" ");
            CsvList.Add("Customer Service");
            CsvList.Add("Customer Service Representative");
        }
        sb.WriteLine(string.Join(",", CsvList));
    }
    System.IO.StreamWriter streamWriter;
    streamWriter = new System.IO.StreamWriter(fileName, true);
    streamWriter.WriteLine(sb.ToString());
    streamWriter.Close();
    Console.WriteLine("File saved as " + fileName);
