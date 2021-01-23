    bool ContainDataRowInDataTable(DataTable T,DataRow R)
    {
        foreach (DataRow item in T.Rows)
        {
            if (Enumerable.SequenceEqual(item.ItemArray, R.ItemArray))
                return true;
        }
        return false;
    }
