    private void comparaeapagarowsiguais(DataTable table1)
    {
        foreach (DataRow row1 in table1.Rows)
        {
            foreach (DataRow row2 in table1.Rows)
            {
                if (row1 != row2) 
                {
                    var array1 = row1.ItemArray;
                    var array2 = row2.ItemArray;
                    if (array1.SequenceEqual(array2))
                    {
                        table1.Rows.Remove(row2);
                    }
                }
            }
        }
    }
