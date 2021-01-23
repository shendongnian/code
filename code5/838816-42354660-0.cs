    // Create a MultipartFormDataContent object
    var multipartContent = new MultipartFormDataContent();
    
    int counter = 0;
    foreach (var question in questions)
    {
        // Serialize each "question" item found in "questions"
    	var questionJson = JsonConvert.SerializeObject(question, 
    	new JsonSerializerSettings
    	{
    		ContractResolver = new CamelCasePropertyNamesContractResolver()
    	});
    
        // Add each serialized question to the multipart object
    	multipartContent.Add(new StringContent(questionJson, Encoding.UTF8, "application/json"), "question" + counter);
    	counter++;
    }
    
    // Post a petition with a  multipart/form-data body
    var response = new HttpClient()
    	.PostAsync("http://multiformserver.com:53908/api/send", multipartContent)
    	.Result;
    
    var responseContent = response.Content.ReadAsStringAsync().Result;
