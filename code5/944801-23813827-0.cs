    WebRequest request = WebRequest.CreateHttp(url);
    request.Method = "POST";
    request.ContentType = "application/json";
    using (var stream = await Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null))
            {
                string postData = JsonConvert.SerializeObject(requestData);
                byte[] postDataAsBytes = Encoding.UTF8.GetBytes(postData);
                await stream.WriteAsync(postDataAsBytes, 0, postDataAsBytes.Length);
            }
    using (var response = await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null))
                        {
                            return await ProcessResponse(response);
                        }
