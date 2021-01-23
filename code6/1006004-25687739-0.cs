    for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
    {
        DataRow dr = ds.Tables[0].Rows[i];
        int auth = (int)dr[0];
        if (auth == 2) continue;
        string notUsed = "NO LONGER USED";
        string notUsed2 = "NO LONGER IN USE";
        if (dr[3].ToString().Contains(notUsed))
        {
            dr.Delete();
        }
        else
        {
            if (dr[3].ToString().Contains(notUsed2))
            {
                dr.Delete();
            }
        }
    }
