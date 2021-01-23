    public static Dictionary<int,T> FetchObjects<T>(string sqlQuery, T obj) where T : BaseClass
    {
        DataTable dt = MyConnection.FetchRecords( sqlQuery );
        Dictionary<int,T> objDict = new Dictionary<int, T>();
        for(int i=0; i < dt.Rows.count; i++ ) {
            obj.MapObjectByDataRow(dt.Rows[i]);      //Abstract function in BaseClass
            objDict.Add(obj.Id, obj);
        }
        return objDict;
    }
