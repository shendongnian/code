    string FilePath = @"C:\Users\me\Downloads\csvfiles\test-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".csv";
    string delimit = ",";
    List<string> cells = new List<string>();
    
    Console.WriteLine("Gathering the data...");
    
    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
    con.Open();
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = con;
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.CommandText = "SELECT id, name FROM contacts";
    
    SqlDataReader reader = cmd.ExecuteReader();
    
    Console.WriteLine("Building the csv file");
    
    while (reader.Read())
    {
        AddCell((IDataRecord)reader, cells);
    }
    
    StringBuilder sb = new StringBuilder();
    
    for (int i = 0; i < cells.Count; i++)
    {
        if (cells[i].Equals("\n"))
        {
            sb.Append(Environment.NewLine);
        }
        else
        {
            sb.Append(cells[i]);
        }
    }
    
    File.WriteAllText(FilePath, sb.ToString());
    
    /*Method to add each record to the list*/
    public static void AddCell(IDataRecord record, List<string> cells)
    {
        cells.Add(record[0].ToString());
        cells.Add(",");
        cells.Add(record[1].ToString());
        cells.Add("\n");
    }
