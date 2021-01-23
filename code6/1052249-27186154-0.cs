        var uploader = new BackgroundUploader
        {
            //ServerCredential = new PasswordCredential {UserName = uploadUser.Name, Password= uploadUser.Password}
        };
        var authHeader = Headers.GetAuthorizationHeader(uploadUser.Name, uploadUser.Password);
        uploader.SetRequestHeader(authHeader.Key,authHeader.Value);
        KeyValuePair<string, string> GetAuthorizationHeader(string username, string password)
        {
            return new KeyValuePair<string, string>(Authorization, "Basic " + EncodeToBase64(string.Format("{0}:{1}", username, password)));
        }
        string EncodeToBase64(string toEncode)
        {
            var bytes = Encoding.UTF8.GetBytes(toEncode);
            var returnValue = Convert.ToBase64String(bytes);
            return returnValue;
        }
        
