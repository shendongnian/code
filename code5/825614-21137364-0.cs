                    var username = uname.Text;
                    var password = pass.Password;
    
                    var postData = "email=" + username + "&password=" + password;
                    WebClient webClient = new WebClient();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var uri = new Uri("Your URL here", UriKind.Absolute);
                    webClient.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();
                    webClient.AllowWriteStreamBuffering = true;
                    webClient.Encoding = System.Text.Encoding.UTF8;
                    webClient.UploadStringAsync(uri, "POST", postData);
                    webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(postComplete);
