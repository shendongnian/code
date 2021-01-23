// Download file from 3rd party API
[HttpGet("[action]")]
public async Task<IActionResult> Download([FromQuery] string fileUri)
{
  // Using rest sharp 
  RestClient client = new RestClient(fileUri);
  client.ClearHandlers();
  client.AddHandler("*", () => { return new JsonDeserializer(); });
  RestRequest request = new RestRequest(Method.GET);
  request.AddParameter("Authorization", string.Format("Bearer " + accessToken), 
  ParameterType.HttpHeader);
  IRestResponse response = await client.ExecuteTaskAsync(request);
  if (response.StatusCode == System.Net.HttpStatusCode.OK)
  {
    // Read bytes
    byte[] fileBytes = response.RawBytes;
    var headervalue = response.Headers.FirstOrDefault(x => x.Name == "Content-Disposition")?.Value;
    string contentDispositionString = Convert.ToString(headervalue);
    ContentDisposition contentDisposition = new ContentDisposition(contentDispositionString);
    string fileName = contentDisposition.FileName;
    // you can write a own logic for download file on SFTP,Local local system location
    //
    // If you to return file object then you can use below code
    return File(fileBytes, "application/octet-stream", fileName);
  }
}
**Using Basic Authentication**
// Download file from 3rd party API
[HttpGet("[action]")]
public async Task<IActionResult> Download([FromQuery] string fileUri)
{ 
  RestClient client = new RestClient(fileUri)
    {
       Authenticator = new HttpBasicAuthenticator("your user name", "your password")
    };
  client.ClearHandlers();
  client.AddHandler("*", () => { return new JsonDeserializer(); });
  RestRequest request = new RestRequest(Method.GET);  
  IRestResponse response = await client.ExecuteTaskAsync(request);
  if (response.StatusCode == System.Net.HttpStatusCode.OK)
  {
    // Read bytes
    byte[] fileBytes = response.RawBytes;
    var headervalue = response.Headers.FirstOrDefault(x => x.Name == "Content-Disposition")?.Value;
    string contentDispositionString = Convert.ToString(headervalue);
    ContentDisposition contentDisposition = new ContentDisposition(contentDispositionString);
    string fileName = contentDisposition.FileName;
    // you can write a own logic for download file on SFTP,Local local system location
    //
    // If you to return file object then you can use below code
    return File(fileBytes, "application/octet-stream", fileName);
  }
}
