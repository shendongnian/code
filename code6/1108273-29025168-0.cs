    List<T> ToList<T>(DataSet dataset): new()
    {
    
    	List<T> list = new List<T>();
    
    	foreach (DataRow row in resp.DataSet.Tables[0].Rows)
    	{
    	    T item = new T();
    	    foreach (PropertyInfo vr in item.GetType().GetProperties())
    	    {
    	        if (resp.DataSet.Tables[0].Columns.Contains(vr.Name.ToString()))
    	        {
    	            vr.SetValue(item, Convert.ChangeType(row[vr.Name], vr.PropertyType), null);
    	        }
    	    }
    
    	    list.Add(item);
    	}
    
    }
