            DataTable table = new DataTable(); 
            for (int i = 0; i < 6; i++) 
            { 
                table.Columns.Add("My column " + i.ToString(), Type.String);
            }   
            for (int i = 0; i < 32; i++) 
            {
                DataRow dr = table.NewRow();
                // populate data row with values here
                table.Rows.Add(dr);
            }
