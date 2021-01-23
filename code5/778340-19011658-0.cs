    ....
        foreach (string column in columns)
            {
                if (row["Name"] == "")
                {
                    row = null;
                    break; //--> Add this line
                }
                else
                {
                    row[column] = cell;
                }
            }
    ....
