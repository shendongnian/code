    // Loop through the rows and output the data
    StringBuilder sb = new StringBuilder();
    while (dr.Read())
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            string value = dr[i].ToString();
            if (value.Contains(","))
                value = "\"" + value + "\"";
            
            sb.Append(value.Replace(Environment.NewLine, " ") + ",");
        }
        sb.Length--; // Remove the last comma
        sb.AppendLine();
    }
    fs.Write(sb.ToString());
