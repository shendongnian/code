    // this is a controller method
    public HttpResponseMessage CreateResponseFromFile()
		{
			var content = File.ReadAllText("yourfile.html");
			if (content == null)
				throw new HttpResponseException(HttpStatusCode.NoContent);
			var response = new HttpResponseMessage
			{
				Content = new StringContent(content)
			};
            response.Content.Headers.Add("Content-Type", "	text/html");  // note this line to set content type
			return response;
		}
