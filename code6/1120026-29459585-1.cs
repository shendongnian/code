    for (int j = 0; j < geometryCollection.Count; j++)
    {
        System.Data.SqlTypes.SqlString wkt = geometryCollection[j].STAsText().ToSqlString();
    
        wktTable.Rows.Add(wkt.ToString());
    }
