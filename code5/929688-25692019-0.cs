    using (var client = new WebClient())
    {    
        var credential = String.Format("{0}:{1}", userName, password);
        var encodedCredential = Convert.ToBase64String(Encoding.UTF8.GetBytes(credential))    
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredential);
    
        // ...
    }
