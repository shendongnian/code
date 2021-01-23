    public class Company
    {
    	public string Id { get; set; }
        // Other properties
    }
    
    public class Requestor
    {
    	public string Id { get; set; }
    
    	public string Email { get; set; }
    
    	public string FirstName { get; set; }
    
    	public string LastName { get; set; }
        // Other properties
    }
    
    public class Container
    {
    	public Company Company { get; set; }
    
    	public Requestor Requestor { get; set; }
    }
    
    var requestor = new Container();
    requestor.Company = new Company { Id = "sampleid" };
    requestor.Requestor = new Requestor
    {
    	FirstName = "test",
    	LastName = "testname"
    };
    
    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    var data = JsonConvert.SerializeObject(requestor, settings);
    
    WebClient client = new WebClient();
    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
    // Code for the credentials etc
    client.UploadString(@"your url", data);
