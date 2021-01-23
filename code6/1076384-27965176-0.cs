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
            
            ShowUser JSONData = null;
            try
            {
                JSONData = (ShowUser)JsonReader.Deserialize(JsonRequest, typeof(ShowUser));
            }
            catch { }
            if (JSONData != null)
            {
                ShowUser UserReturn = new ShowUser();
                UserReturn.UserName = "BaseUser";
                return Request.CreateResponse(HttpStatusCode.OK, UserReturn);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ShowUser not provided");
            }
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
                ShowUser UserReturn = new ShowUser();
                UserReturn.UserName = "CarUser";
                return Request.CreateResponse(HttpStatusCode.OK, UserReturn);
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
