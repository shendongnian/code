public void LoopLink() {
	int count = LinkElements.Count;
	for (int i = 0; i < count; i++)
	{
		var link = LinkElements[i];
		var href = link.GetAttribute("href");
		//ignore the anchor links without href attribute
		if (string.IsNullOrEmpty(href))
			continue;
		using (var webclient = new HttpClient())
		{
			var response = webclient.GetAsync(href).Result;
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
	}
}
