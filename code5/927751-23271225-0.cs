    class LoginData
    {
       public string Username {get;set;}
       public string UserPassword {get;set;}
    }
    
    
    public class CheckAuthenticationController : ApiController
    {
        public object Post(LoginData loginData)
        {
            try
            {
                return GeneralFunctions.CheckAuthentication(loginData.Username , loginData.UserPassword );
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
        }
    }
