        // Read all lines and get back an array of the lines
        string[] lines = File.ReadAllLines(csvPath);
        // Loop over the lines and try to add them to the table
        foreach (string row in lines)
        {
            // Discard if the line is just null, empty or all whitespaces
            if (!string.IsNullOrWhiteSpace(row))
            {
                string[] rowParts = row.Split(',');
                // We expect the line to be splittes in 7 parts. 
                // If this is not the case then log the error and continue
                if(rowParts.Length != 7)
                {
                    // Log here the info on the incorrect line with some logging tool
                    continue;
                }
                // Check if the 3 values expected to be integers are really integers
                int pataintno;
                int age;
                int phno;
                if(!Int32.TryParse(rowParts[0], out pataintno))
                {
                   // It is not an integer, so log the error
                   // on this line and continue
                   continue;
                }
                if(!Int32.TryParse(rowParts[3], out age))
                {
                   // It is not an integer, so log the error
                   // on this line and continue
                   continue;
                }
                if(!Int32.TryParse(rowParts[6], out phno))
                {
                   // It is not an integer, so log the error
                   // on this line and continue
                   continue;
                }
                // OK, all is good now, try to create a new row, fill it and add to the 
                // Rows collection of the DataTable
                DataRow dr = dt.NewRow();
                dr[0] = pataintno;
                dr[1] = rowParts[1].ToString();
                dr[2] = rowParts[2].ToString();
                dr[3] = age
                dr[4] = rowParts[4].ToString();
                dr[5] = rowParts[5].ToString();
                dr[6] = phno;
                dt.Rows.Add(dr);
            }
        }
