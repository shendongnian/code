       using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-      urlencoded";
            var data = new Person 
            { 
                  Name = "Glitch100"
            }
            var result = client.UploadString("http://www.website.com/page/", "POST", data);
            Console.WriteLine(result);
        }
