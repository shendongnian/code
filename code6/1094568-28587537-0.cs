	var ctor = typeof(SqlErrorCollection).GetConstructors(
      BindingFlags.Instance 
    | BindingFlags.NonPublic 
    | BindingFlags.NonPublic).FirstOrDefault();
    var coll = (SqlErrorCollection)ctor.Invoke(null);
	var extype = typeof(SqlException).GetConstructors(
      BindingFlags.Instance 
    | BindingFlags.NonPublic 
    | BindingFlags.NonPublic).FirstOrDefault();
	var ex = extype.Invoke(new object[] { "Test", coll, null, new Guid() });
	var prop = ex.GetType().GetProperty("Errors");
	if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType)
		&& typeof(ICollection).IsAssignableFrom(prop.PropertyType) )
		// && prop.PropertyType.IsGenericType)
	{
		var val = prop.GetValue(ex, null);
		Console.WriteLine(val);
	}
