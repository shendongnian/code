     using (var client = new WebClient())
    {
        var uri = new Uri(_easypostHosts[2] + UploadUri.FormatWith(sessionId, HttpUtility.UrlEncode(fileName)));
        // get the auth headers which are already stored when we create the session
        var digestHeader = DigestAuthFixer.GetDigestHeader(uri.PathAndQuery, "PUT");
        // add the auth header to our web client
        client.Headers.Add("Authorization", digestHeader);
        // trying to use the UploadFile() method doesn't work in this case. so we get the bytes and upload data directly 
        byte[] fileBytes = File.ReadAllBytes(filePath);
        // as a PUT request
        var result = client.UploadData(uri, "PUT", fileBytes);
        // result is also a byte[].
        content = result.Length.ToString();
    } 
