    // Each row will be an element of this list
    List<string> rows = new List<string>();
    for (int a = 0; a < dsDeviceMatch2.Tables[0].Rows.Count; a++)
    {
        StringBuilder result = new StringBuilder();
        for (int b = 0; b < dsDeviceMatch2.Tables[0].Columns.Count; b++)
        {
            result.Append(dsDeviceMatch2.Tables[0].Rows[a][b].ToString() + ",");
        }
        // Add the row to the list removing the last comma
        rows.Add(result.ToString(0, result_1.Length - 1); 
    }
