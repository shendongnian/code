    foreach(DataRow row in TheTable.Rows)
    {
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
    }
