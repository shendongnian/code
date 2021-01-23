	var list = ctx.Web.Lists.GetById(libGuid);
	var fields = list.Fields;
	ctx.Load(list);
	ctx.Load(fields);
	ctx.ExecuteQuery();
	List<object> fieldPropList = new List<object>();
	foreach (Field f in fields)
	 {
	    ctx.Load(f);   //  <<== *** LOAD THE FIELD ***
	    List<PropertyInfo> props = f.GetType().GetProperties().ToList();
	    foreach (var prop in props)
	    {
		if (prop.Name == "Hidden")
		{
		    fieldPropList.Add(new
		    {
			PropertyName = prop.Name,
			PropertyType = prop.PropertyType.ToString(),
			CanRead = prop.CanRead,
			CanWrite = prop.CanWrite,
			Value = prop.GetValue(f, null).ToString()  // Always TRUE why?
		    });
		}
	    }
