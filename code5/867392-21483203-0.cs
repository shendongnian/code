    //so instead of using:
    //request.Credentials = cc;
    //request.PreAuthenticate = true;
    //you should call:
        SetBasicAuthHeader(request,  "my_email", "my_password")
        }
        public void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
        }
