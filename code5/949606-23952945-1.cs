        public Response ValidateLogin(string Username, string Password) 
        {
            Response result=new Response();
    
            if (Username.Equals("Admin") && Password.Equals("pass123"))
            {
                result.Result= true;
                return result;
            }
            else 
            {
                result.Result= false;
                return result;
            }
        }
    public class Response()
    {
       private bool Result {get;set;}
    }
