    private static List<T> ConvertDataTable<T>(DataTable dt)  
    {  
       List<T> data = newList<T>();  
       foreach (DataRowrow in dt.Rows)  
       {  
          Titem = GetItem<T>(row);  
          data.Add(item);  
       }  
       return data;  
    }  
      
    private static TGetItem<T>(DataRow dr)  
    {  
       Type temp = typeof(T);  
       T obj =Activator.CreateInstance<T>();  
       foreach (DataColumncolumn in dr.Table.Columns)  
       {  
          foreach (PropertyInfopro in temp.GetProperties())  
          {  
             if (pro.Name == column.ColumnName)  
             pro.SetValue(obj,dr[column.ColumnName], null);  
             else  
             continue;  
          }  
       }  
       return obj;  
    }  
