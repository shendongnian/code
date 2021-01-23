    DataTable dataTable = record.Select(...) // Your data coming from DB
    // Remove Empty Columns
    if (dataTable.AsEnumerable().All(dr => dr.IsNull("ColumnName"))) // column name having null values
       dataTable.Columns.Remove("ColumnName");
    List<Cars> listOfCarRecords = dataTable.ToCollection<Cars>;
    dataGridView1.DataSource = listOfCarRecords;
    // ToCollection is an extension methods for converting generic class to List
    public static List<T> ToCollection<T>(this DataTable sourceDatatable)
    {
        var lst = new List<T>();
            
        Type tClass = typeof(T);
        PropertyInfo[] pClass = tClass.GetProperties();
        List<DataColumn> dc = sourceDatatable.Columns.Cast<DataColumn>().ToList();
       foreach (DataRow item in sourceDatatable.Rows)
       {
         var genericObject = (T)Activator.CreateInstance(tClass);
         foreach (PropertyInfo pc in pClass)
         {
            DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
            if (d != null)
               pc.SetValue(genericObject, item[pc.Name], null);
         }
         lst.Add(genericObject);
      }
      return lst;
    }
