    public class HttpHelper : IHttpHelper
    {
          public KeyValuePair<string, string>
                 CreateAuthorizationHeader(ICredentials credentials)
          {
              NetworkCredential networkCredential = 
                  credentials.GetCredential(null, null);
              string userName = networkCredential.UserName;
              string userPassword = networkCredential.Password;
              string authInfo = userName + ":" + userPassword;
              authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
              return new KeyValuePair<string, string>("Authorization", "Basic " + authInfo);
         }
    }
