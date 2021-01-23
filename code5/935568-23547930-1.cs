    // Send binary data and string data in a single request.
    MultipartFormDataContent multipartContent = new MultipartFormDataContent();
    multipartContent.Add(byteContent);
    multipartContent.Add(stringContent);
    HttpResponseMessage reponse = await client.PostAsync(uri, multipartContent);
