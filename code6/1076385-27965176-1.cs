        /// <summary>
    /// Notice name is not Controller.cs  This would expose this API if the name ended in controller
    /// </summary>
    public class GenericControllerApi : ApiController
    {
        protected JavaScriptSerializer JsonReader = new JavaScriptSerializer();
        [HttpPost]
        public virtual HttpResponseMessage Login()
        {
            string JsonRequest = Request.Content.ReadAsStringAsync().Result;
            
            LoginRequest JSONData = null;
            try
            {
                JSONData = (LoginRequest)JsonReader.Deserialize(JsonRequest, typeof(LoginRequest));
            }
            catch { }
            if (JSONData != null)
            {
                if (CommonUserCalls(JSONData.User))
                {
                    ShowUser UserReturn = new ShowUser();
                    UserReturn.UserName = "BaseUser";
                    return Request.CreateResponse(HttpStatusCode.OK, UserReturn);
                }
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ShowUser not provided");
            }
        }
        protected bool CommonUserCalls(string User)
        {
            if (User == "MyUser")
            {
                return true;
            }
            return false;
        }
        public class LoginRequest
        {
            public string User { get; set; }
        }
        protected class ShowUser
        {
            public string UserName { get; set; }
        }
    }
    public class CarController : GenericControllerApi
    {
        [HttpPost]
        public override HttpResponseMessage Login()
        {
            string JsonRequest = Request.Content.ReadAsStringAsync().Result;
            CarWebsiteLoginRequest JSONData = null;
            try
            {
                JSONData = (CarWebsiteLoginRequest)JsonReader.Deserialize(JsonRequest, typeof(CarWebsiteLoginRequest));
            }
            catch { }
            if (JSONData != null)
            {
                if (CommonUserCalls(JSONData.User))
                {
                    ShowUser UserReturn = new ShowUser();
                    UserReturn.UserName = "CarUser";
                    return Request.CreateResponse(HttpStatusCode.OK, UserReturn);
                }
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "CarWebsiteLoginRequest not provided");
            }
        }
        public class CarWebsiteLoginRequest : LoginRequest
        {
            public string Car { get; set; }
        }
    }
