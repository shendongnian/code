    StringBuilder result = new StringBuilder();
    for (int a = 0; a < dsDeviceMatch2.Tables[0].Rows.Count; a++)
    {
        for (int b = 0; b < dsDeviceMatch2.Tables[0].Columns.Count; b++)
        {
            result.Append(dsDeviceMatch2.Tables[0].Rows[a][b].ToString() + ",");
        }
    }
    string Cmp_Cd_Typ_Id1_1 = result.ToString();
