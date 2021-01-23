	var customer = new Customer() {  Civility = "Mr.", Name = "Max", Surname = "Mustermann" };
	var order = new Order();
	string Source = "Dear @Customer.Civility, @Customer.Name @Customer.Surname\n\n About your bill dated @Order.Date...";
	string s = BringTheMash(Source, new { Customer = customer, Order = order });
	Console.WriteLine(s);
	private static string BringTheMash(string format, object p)
	{
		string result = format;
		var regex = new Regex(@"@(?<object>\w+)\.?(?<property>\w+)");
		foreach (Match m in regex.Matches(Source))
		{
			var obj = m.Groups[1].ToString();
			var prop = m.Groups[2].ToString();
			var parameter = p.GetType().GetProperty(obj).GetValue(p);
			var value = parameter.GetType().GetProperty(prop).GetValue(parameter);
			result = result.Replace(m.Value, value.ToString());
		}
		return result;
	}
