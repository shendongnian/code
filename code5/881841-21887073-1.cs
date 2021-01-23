        foreach (DataRow r in dt.Rows)
        {
            if (dt.Rows.Count > 0)
            {
                int index = -1;
                foreach (DataColumn dc in dt.Columns)
                {
                    index++;
                    if (index != dt.Rows.Count)
                    {
                    table.AddCell(new Phrase(r[index].ToString(), font5));
                    }
                    
                }
            }
        } 
