	public void SampleClientCode()
	{
		using (var client = new ServiceReference1.Service1Client())
		{
			List<Person> results = client.GetData("12345");
			// Now do something with the data... Example
            string firstPersonsName = results.First().nameps;
		}
	}
