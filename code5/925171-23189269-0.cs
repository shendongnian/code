    public class TestController : ApiController
    {
      [HttpPost]
      public void Test(HttpRequestMessage request)
      {
        var content = request.Content;
        string jsonContent = content.ReadAsStringAsync().Result;
        Test test = new Test();
        test = JsonConvert.DeserializeObject<Test>(jsonContent);
        //Do validation stuff...
      }
    }
