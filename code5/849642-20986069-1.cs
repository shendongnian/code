     public class StringsController : ApiController
     {
        /// <summary>
        /// Get one entry from indexOfStrings
        /// </summary>
        public string Get(int listIndex)
        {
            var myService = Request.Properties["MyService_Key"] as MyService;
            // How to return indexOfStrings[listIndex]?
            var mystring = myService.GetMyString(99);
            return "";
        }
    }
