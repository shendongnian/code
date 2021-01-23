    // Create list of messages that will be sent
    IEnumerable<IMessageApiEntity> messages = new List<IMessageApiEntity>();
    // Add messages to the list here. 
    // They are all different types that implement the IMessageApiEntity interface.
    
    // Create http client
    HttpClient client = new HttpClient {BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiUrl"])};
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    // Post to web api (this is the part that changed)
    JsonMediaTypeFormatter json = new JsonMediaTypeFormatter
    {
        SerializerSettings =
        {
            TypeNameHandling = TypeNameHandling.All
        }
    };
    HttpResponseMessage response = client.PostAsync("Communications/Messages", messages, json).Result;
    
    // Read results
    IEnumerable<ApiResponse<IMessageApiEntity>> results = response.Content.ReadAsAsync<IEnumerable<ApiResponse<IMessageApiEntity>>>().Result;
