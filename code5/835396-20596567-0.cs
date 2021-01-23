    foreach (DataRow dr in dt.Rows)
    {
        temp[i] = new DataTable(); // <--------
        for (i = 0; i < dt.Rows.Count;i++)
        {
            temp[i].Rows.Add(dr.ItemArray);
            break;
        }
    }
