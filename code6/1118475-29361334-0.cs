       public class LoginController : ApiController
            {
                public bool Validate([FromUri]Creds creds)
                {
                    return false;
                }
            }
