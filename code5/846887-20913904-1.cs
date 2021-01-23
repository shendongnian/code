    [RoutePrefix("api/client/{clientId}/Contact")]
    public class ContactController
    {
        // this uses conventional route
        public ContactModel GetContactByID(string id)
        {
            ...
        }
    
        [Route("username/{userName}")]
        public ContactModel GetContactByUserName(string userName)
        {
            ...
        }
    }
