    public static class HelperExtensions
    {
      public static List<dynamic> ToDynamic(this DataTable dt)
      {
        var dynamicDt = new List<dynamic>();
        foreach (DataRow row in dt.Rows)
        {
          dynamic dyn = new ExpandoObject();
          dynamicDt.Add(dyn);
          foreach (DataColumn column in dt.Columns)
          {
             var dic = (IDictionary<string, object>)dyn;
             dic[column.ColumnName] = row[column];
          }
        }
        return dynamicDt;
      }
    }
