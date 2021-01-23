    private void prepdatatable(DataTable dt, int rowcount, int colcount)
        {
            int i = 0;
    
            for (i = 0; i < colcount; i++)
            {
                dt.Columns.Add("col" + i);
            }
    
            for (i = 0; i < rowcount; i++)
            {
                var r = dt.NewRow();
                dt.Rows.Add(r);
            }
        }
