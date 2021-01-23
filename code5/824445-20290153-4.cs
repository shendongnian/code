    DataRow row;
    // Create new DataRow objects and add to DataTable.     
    for(int i = 0; i < 10; i++)
    {
        row = YourDataTable.NewRow();
        
        row["Name"] = theName;
        
        // Loop through each city
        for (int y = 0; y < (lengthofAddress); y++)
        {
            // Determine if each city is a match or not,
            // if so then put "X" in that row's cell here
            if(match)
            {
                row[y+1] = "X";
            }            
        }
        
        YourDataTable.Rows.Add(row);
    }
