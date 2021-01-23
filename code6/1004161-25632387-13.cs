    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserInfoDto));
	var data = new UserInfoDto { Age = 30, UserName = "John" };
	data.Address = new AddressDto { Street = "123 ABC" };
	using (MemoryStream stream = new MemoryStream())
	{
		using (StreamReader reader = new StreamReader(stream))
		{
			serializer.WriteObject(stream, data);
			stream.Position = 0;
			var output = reader.ReadToEnd();
		}
	}
