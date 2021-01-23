    SqlDbType[] sqlDType = new SqlDbType[] {SqlDbType.Int, SqlDbType.Float, SqlDbType.SmallInt, SqlDbType.TinyInt};
    int[] sqlSize = new int[] { 4, 8, 2, 1 };
    SqlDbType type = SqlDbType.Float;
    int iIndex = Array.IndexOf(sqlDType, type);
    int iSize = -1;
    if (iIndex > -1)
    	iSize = sqlSize[iIndex];
