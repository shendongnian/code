    List<string> Cmp_Cd_Typ_Id1_1 = new List<string>;
    for (a = 0; a < dsDeviceMatch2.Tables[0].Columns.Count; a++)
    {
        for (b = 0; b < dsDeviceMatch2.Tables[0].Columns.Count; b++)
        {
            Cmp_Cd_Typ_Id1_1.Add(dsDeviceMatch2.Tables[0].Rows[a][b].ToString());
        }
    }
