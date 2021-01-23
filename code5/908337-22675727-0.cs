		private T ReadJson<T>(Stream stream)
		{
			using (var reader = new StreamReader(stream))
			{
				using (var jr = new JsonTextReader(reader))
				{
					dynamic d = new JsonSerializer().Deserialize(jr);
					return d;
				}
			}
		}
    //...
	var d = ReadJson<dynamic>(new MemoryStream(Encoding.UTF8.GetBytes("{'MyProperty' : 'MyValue'}")));
	Debug.WriteLine((String)d.MyProperty);
