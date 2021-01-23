    private void comparaeapagarowsiguais(DataTable table1)
    {
        foreach (DataRow row1 in table1.Rows)
        {
            var toDelete = table1.AsEnumerable().Where(row => row.ItemArray.SequenceEqual(row1.ItemArray));
            foreach (DataRow r in toDelete)
	        {
                table1.Rows.Remove(r);
            }
        }
    }
