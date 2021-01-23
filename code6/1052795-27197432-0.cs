	var settings = new JsonSerializerSettings() {
		Formatting = Formatting.Indented,
		ContractResolver = new DefaultContractResolver() { 
			IgnoreSerializableInterface = true 
		} 
	};
	Console.WriteLine(JsonConvert.SerializeObject(new MyException {MyProperty = "foobar"}, settings));
