    for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            DataRow row = dt.Rows[i];
            if (row["Column2"].ToString() == "This Value")
            {
                dt2nd.ImportRow(row); //Copy
                dt.Rows.Remove(row); //Remove
                continue;
            }
            if (row["Column2"].ToString() == "Other Value")
            {
                dt2nd.ImportRow(row); //Copy
                dt.Rows.Remove(row); //Remove
                continue; 
            }
            //This continues with more if
        }
