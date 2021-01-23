    WebClient webClient = new System.Net.WebClient();
    Uri uri = new Uri("http://serverDomain:8080/pentaho/Home");
    //Give user name and password here
    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("username:password");
    var encodedString = System.Convert.ToBase64String(plainTextBytes);
    webClient.Headers["Authorization"] = "Basic " + encodedString;
    webClient.Encoding = Encoding.UTF8;
    App.WindowManager.ConsoleWrite(uri.ToString());
    webClient.UploadStringAsync(uri, "POST", "");
