    var ordFunc = new Func<System.Reflection.PropertyInfo, int>(p => ((OrderAttribute) p.GetCustomAttributes(typeof (OrderAttribute), false)[0]).Order);
	
	if(!objects.Any())
		return;
	
	var properties = objects.First().GetType().GetProperties()
		.OrderBy(ordFunc)
		.ToArray();
		
	foreach (var obj in objects)
	{
		fileWriter.WriteLine(String.Join(",", properties.Select(x => x.GetValue(obj).ToString())));
	}
