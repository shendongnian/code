    var sb = new StringBuilder();
    foreach (DataRow row in dt.Rows)
    {
        List<string> csvList = new List<string>();
        foreach (var item in row.ItemArray)
        {
            csvList.Add(item.ToString());
        }
        if (i == 1)
        {
            csvList.Add(" ");
            csvList.Add("Customer Service");
            csvList.Add("Customer Service Representative");
        }
        sb.WriteLine(string.Join(",", csvList));
    }
    System.IO.StreamWriter streamWriter;
    streamWriter = new System.IO.StreamWriter(fileName, true);
    streamWriter.WriteLine(sb.ToString());
    streamWriter.Close();
    Console.WriteLine("File saved as " + fileName);
