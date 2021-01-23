    var client = new HttpClient();
    var response = client.PostAsJsonAsync<YourObject>("http://yourserviceurl:port/controller", objectToPost).Result;
    if(response.IsSuccessStatusCode){
        Console.WriteLine(response);
    }else{
        Console.WriteLine(response.StatusCode);
    }
