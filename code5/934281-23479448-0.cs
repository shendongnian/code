    var rows = new List<string>();
    
    if (userdetails.username != "")
       rows.Add(string.Format("Username: {0}" userdetails.username));
    else
       rows.Add("Username: Unknown");
    
    row.Add(string.Empty);
    
    // create the rows you need to append
    StringBuilder sb = new StringBuilder();
    foreach (string row in rows)
    	sb.AppendFormat(",{0}", row);
    
    // flush all rows once time.
    File.AppendAllText(filePath, sb.ToString(), Encoding.UTF8);
