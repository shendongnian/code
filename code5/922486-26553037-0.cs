    public HttpResponseMessage Get()
    {
        var item = new List<dynamic> { new TestClass { Name = "Ale", Age = 30 } };
        return Request.CreateResponse(HttpStatusCode.OK, item);
    }
    public class TestClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
