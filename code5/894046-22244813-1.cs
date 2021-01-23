    public ActionResult Index()
    {
        var users = GetApiUsers();
        return View(users);
    }
    
    private IList<User> GetApiUsers()
    {
        const string apiBaseUrl = "http://localhost:52812/Api/";
        const string apiSuffix = "ApiExample/GetAllUsers";
    
        var client = new RestClient(apiBaseUrl);
    
        var request = new RestRequest(apiSuffix, Method.GET);
    
        var response = (RestResponse<List<User>>)client.Execute<List<User>>(request);
        return response.Data;
    }
