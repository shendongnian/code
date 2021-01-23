        //prepare the output stream
        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AppendHeader("Content-Disposition",
            string.Format("attachment; filename={0}", fileName));
        string value = "";
        StringBuilder builder = new StringBuilder();
        //write the csv column headers
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            value = dt.Columns[i].ColumnName;
            // Implement special handling for values that contain comma or quote
            // Enclose in quotes and double up any double quotes
            if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
            else
            {
                builder.Append(value);
            }
            Response.Write(value);
            Response.Write((i < dt.Columns.Count - 1) ? delimiter : Environment.NewLine);
            builder.Clear();
        }
        //write the data
        foreach (DataRow row in dt.Rows)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                value = row[i].ToString();
                // Implement special handling for values that contain comma or quote
                // Enclose in quotes and double up any double quotes
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                else
                {
                    builder.Append(value);
                }
                Response.Write(builder.ToString());
                Response.Write((i < dt.Columns.Count - 1) ? delimiter : Environment.NewLine);
                builder.Clear();
            }
        }
        Response.End();
    }
