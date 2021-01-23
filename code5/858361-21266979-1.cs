	[Route("cars"), HttpPost]
	public IHttpActionResult AddCar()
	{
	HttpContent content = Request.Content;
	string carJson = content.ReadAsStringAsync().Result;
	// You now have the original JSON and can examine it before deserialization
	}
