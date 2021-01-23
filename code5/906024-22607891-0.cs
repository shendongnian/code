    private async Task<bool> SendEmailAsync(long studentId, LoginModel loginModel)
    {
        Task<bool> uploadTask = Task.Factory.StartNew<bool>(
            () =>
            {
                try
                {
                    string URI = ConfigurationManager.AppSettings["CommunicationmanagerURL"] + "PostUserEvent";
                    var serializer = new JavaScriptSerializer();
    
                    string requestData = serializer.Serialize(new
                    {
                        EventID = 1,
                        SubscriberID = studentId,
                        ToList = loginModel.EmailAddress,
                        TemplateParamVals = strStudentDetails,
                    });
    
                    using (var client = new WebClient())
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        var result = client.UploadData(URI, Encoding.UTF8.GetBytes(requestData));
    
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Log exceptions ...
                    return false;
                }
            });
        return uploadTask;
    }
