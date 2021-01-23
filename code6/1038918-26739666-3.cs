    public static DbGeography CreatePolygon(string wktString)
    {
    	var sqlGeography = SqlGeography.STGeomFromText(new SqlChars(wktString), 4326).MakeValid();
     
    	var invertedSqlGeography = sqlGeography.ReorientObject();
     	if (sqlGeography.STArea() > invertedSqlGeography.STArea())
     	{
     		sqlGeography = invertedSqlGeography;
     	}
     
    	return DbGeography.FromText(sqlGeography.ToString());
    }
