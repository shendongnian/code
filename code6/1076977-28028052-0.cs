    /// <summary>
    /// Summary description for StatusWebService
    /// </summary>
    [WebService(Namespace = "http://test.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StatusWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public void ReceiveStatusUpdate(StatusUpdate StatusUpdate)
        {
            //Do whatever needs to be done with the status update
        }
    }
    public class StatusUpdate
    {
        public string Reference { get; set; }
        public string ThirdPartyReference { get; set; }
        public string Status { get; set; }
    }
