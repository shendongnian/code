    MyEntity editItem=new MyEntity();  
    foreach (List<string> data in importData) //loop each xls row
    {
    	foreach (PropertyInfo pr in MyEntity.GetType().GetProperties())
    	{
    		int excelindex = -1;
          		if (excelFields.Keys.Contains(pr.Name))
          		{
    			excelFields.TryGetValue(pr.Name, out excelindex);
    			editItem.GetType().GetProperty(pr.Name).SetValue(editItem, Convert.ChangeType(data[excelindex], editItem.GetType).GetProperty(pr.Name).PropertyType), null);
    		}
    	}
    }
