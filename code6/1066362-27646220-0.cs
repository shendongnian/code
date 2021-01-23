        string[] lines = File.ReadAllLines(csvPath);
        foreach (string row in lines)
        {
            if (!string.IsNullOrWhiteSpace(row))
            {
                DataRow dr = dt.NewRow();
                string[] rowParts = row.Split(',');
                int pataintno;
                int age;
                int phno;
                if(!Int32.TryParse(rowParts[0], out pataintno))
                {
                   // Log the error on this line and continue
                   continue;
                }
                if(!Int32.TryParse(rowParts[3], out age))
                {
                   // Log the error on this line and continue
                   continue;
                }
                if(!Int32.TryParse(rowParts[6], out phno))
                {
                   // Log the error on this line and continue
                   continue;
                }
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
