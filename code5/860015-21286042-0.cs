    public static DataTable FromCSV(string FilePath, char Delimiter = ',')
    {
        DataTable dt = new DataTable();
        Dictionary<string, string> props = new Dictionary<string, string>();
        if (!File.Exists(FilePath))
            return null;
        if (FilePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            props["Provider"] = "Microsoft.Ace.OLEDB.12.0";
            props["Extended Properties"] = "\"Text;FMT=Delimited\"";
            props["Data Source"] = Path.GetDirectoryName(FilePath);
        }
        else
            return null;
        StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<string, string> prop in props)
        {
            sb.Append(prop.Key);
            sb.Append('=');
            sb.Append(prop.Value);
            sb.Append(';');
        }
        string connectionString = sb.ToString();
        File.Delete(Path.GetDirectoryName(FilePath) + "/schema.ini");
        using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(FilePath) + "/schema.ini", false))
        {
            sw.WriteLine("[" + Path.GetFileName(FilePath) + "]");
            sw.WriteLine("Format=Delimited(" + Delimiter + ")");
            sw.WriteLine("DecimalSymbol=.");
            sw.WriteLine("ColNameHeader=True");
            sw.WriteLine("MaxScanRows=1");
            sw.Close();
            sw.Dispose();
        }
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM [" + Path.GetFileName(FilePath) + "] WHERE 1=0";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(FilePath) + "/schema.ini", true))
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string NewColumnName = dt.Columns[i].ColumnName.Replace(@"""", @"""""");
                    int ColumnNamePosition = NewColumnName.LastIndexOf("#csv.", StringComparison.OrdinalIgnoreCase);
                    if (ColumnNamePosition != -1)
                        NewColumnName = NewColumnName.Substring(ColumnNamePosition + "#csv.".Length);
                    if (NewColumnName.StartsWith("NoName"))
                        NewColumnName = "F" + (i + 1).ToString();
                    sw.WriteLine("col" + (i + 1).ToString() + "=" + NewColumnName + " Text");
                }   
                sw.Close();
                sw.Dispose();
            }
            dt.Columns.Clear();
            cmd.CommandText = "SELECT * FROM [" + Path.GetFileName(FilePath) + "]";
            da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd = null;
            conn.Close();
        }
        File.Delete(Path.GetDirectoryName(FilePath) + "/schema.ini");
        return dt;
    }
