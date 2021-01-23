    public static DataTable ObjectToData(object o)
         {
             DataTable dt = new DataTable("OutputData");
             DataRow dr = dt.NewRow();
             dt.Rows.Add(dr);
             o.GetType().GetProperties().ToList().ForEach(f =>
             {
                 try
                 {
                     f.GetValue(o, null);
                     dt.Columns.Add(f.Name, f.PropertyType);
                     dt.Rows[0][f.Name] = f.GetValue(o, null);
                 }
                 catch { }
             });
             return dt;
         }
