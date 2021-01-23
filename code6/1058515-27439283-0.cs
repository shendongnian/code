    public class MyController : ApiController
    {
	  public async Task Post()
	  {
  		if (!Request.Content.IsMimeMultipartContent())
			  throw new    HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable,"This request is not properly formatted"));
 
		var provider = new MultipartMemoryStreamProvider();
		await Request.Content.ReadAsMultipartAsync(provider);
 
		foreach (HttpContent ctnt in provider.Contents)
		{
			//now read individual part into STREAM
			var stream = await ctnt.ReadAsStreamAsync();
			if (stream.Length != 0)
			{
				//handle the stream here
			}
		}
	}
