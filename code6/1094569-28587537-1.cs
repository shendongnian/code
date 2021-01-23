    // create inner sql error collection instance through reflection
	var sqlErrorCollCtor = typeof(SqlErrorCollection).GetConstructors(
      BindingFlags.Instance 
    | BindingFlags.NonPublic 
    | BindingFlags.NonPublic).FirstOrDefault();
    var errorCollection = (SqlErrorCollection)sqlErrorCollCtor.Invoke(null);
    // create sql exception instance through reflection
	var sqlExceptionCtor = typeof(SqlException).GetConstructors(
      BindingFlags.Instance 
    | BindingFlags.NonPublic 
    | BindingFlags.NonPublic).FirstOrDefault();
	var exception = sqlExceptionCtor.Invoke(
      new object[] { "Test", errorCollection, null, new Guid() });
    // retrieve Errors property
	var prop = exception.GetType().GetProperty("Errors");
	if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType)
		&& typeof(ICollection).IsAssignableFrom(prop.PropertyType) )
		// && prop.PropertyType.IsGenericType)
	{
		var val = prop.GetValue(exception, null);
		Console.WriteLine(val);
	}
