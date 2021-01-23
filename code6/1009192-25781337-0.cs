    //add reference System.Data
    //add reference System.Web.extensions
    //add reference System.Web.DataTableExtensions
    public static string ConvertToJson(DataTable dt, int page = 0, int count = 100)
    {
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var rows = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt.AsEnumerable().Skip(page * count).Take(count).ToList())
        {
            rows.Add(dt.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => dr[col]));
        }
        return serializer.Serialize(rows);
    }
