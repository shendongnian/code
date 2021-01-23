    string password = "5agbe1d6f774634169e9ba4625559bc83f";  // AKA the Jenkins AuthToken
    string userName = "YOUR.USERNAME";						 // AKA your Jenkins userID
    
    var webClient = new System.Net.WebClient();
    
    // Create a basic auth token from a username and password seperated by a colon then base 64encoded
    string basicAuthToken = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
    webClient.Headers["Authorization"] = "Basic " + basicAuthToken;
    
    return client.UploadString(path, definition, headers);
