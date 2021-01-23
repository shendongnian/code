    // 2. Create the url 
    string url = "https://myurl.com/api/...";
    string filename = "myFile.png";
    // In my case this is the JSON that will be returned from the post
    string result = "";
    // 1. Create a MultipartPostMethod
    // "NKdKd9Yk" is the boundary parameter
    using (var formContent = new MultipartFormDataContent("NKdKd9Yk")) {
    
        formContent.Headers.ContentType.MediaType = "multipart/form-data";
        // 3. Add the filename C:\\... + fileName is the path your file
        Stream fileStream = System.IO.File.OpenRead("C:\\Users\\username\\Pictures\\" + fileName);
        formContent.Add(new StreamContent(fileStream), fileName, fileName);
        using (var client = new HttpClient())
        {
            // Bearer Token header if needed
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _bearerToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                
            try
            {
                // 4.. Execute the MultipartPostMethod
                var message = await client.PostAsync(url, formContent);
                // 5.a Receive the response
                result = await message.Content.ReadAsStringAsync();                
            }
            catch (Exception ex)
            {
                // Do what you want if it fails.
                throw ex;
            }
        }    
    }
    // 5.b Process the reponse Get a usable object from the JSON that is returned
    MyObject myObject = JsonConvert.DeserializeObject<MyObject>(result);
