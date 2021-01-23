    foreach (DataRow dr in dt.Rows)
    {
        for (i = 0; i < dt.Rows.Count;i++)
        {
            temp[i] = new DataTable(); // <--------
            temp[i].Rows.Add(dr.ItemArray);
            break;
        }
    }
