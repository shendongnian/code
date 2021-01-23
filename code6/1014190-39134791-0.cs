    public class MapItem
    {
        public Type Type { get; private set; }
        public DataRetriveTypeEnum DataRetriveType { get; private set; }
        public string PropertyName { get; private set; }
        public MapItem(Type type, DataRetriveTypeEnum dataRetriveType, string propertyName)
        {
            Type = type;
            DataRetriveType = dataRetriveType;
            PropertyName = propertyName;
        }
    }
     
     //And then make a reusable function like below
    protected async Task<dynamic> ExecuteQueryMultipleAsync(IDbConnection con, string spName, object param = null,IEnumerable<MapItem> mapItems = null)
        {
            var data = new ExpandoObject();
            using (var multi = await con.QueryMultipleAsync(spName,param, commandType:CommandType.StoredProcedure))
            {
                if (mapItems == null) return data;
                foreach (var item in mapItems)
                {
                    if (item.DataRetriveType == DataRetriveTypeEnum.FirstOrDefault)
                    {
                        var singleItem = multi.Read(item.Type).FirstOrDefault();
                        ((IDictionary<string, object>) data).Add(item.PropertyName, singleItem);
                    }
                    if (item.DataRetriveType == DataRetriveTypeEnum.List)
                    {
                        var listItem = multi.Read(item.Type).ToList();
                        ((IDictionary<string, object>)data).Add(item.PropertyName, listItem);
                    }
                }
                return data;
            }
        }
