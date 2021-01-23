    for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            DataRow row = dt.Rows[i];
            switch(row["Column2"].ToString()){
            case "This Value":
            {
                dt2nd.ImportRow(row); //Copy
                dt.Rows.Remove(row); //Remove
                break;
            }
            case "Other Value":
            {
                dt2nd.ImportRow(row); //Copy
                dt.Rows.Remove(row); //Remove
                break; 
            }
            //This continues with more case
        }
