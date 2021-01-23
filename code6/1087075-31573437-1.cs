    public class InvoiceController : ApiController
    {
        public async Task<IHttpActionResult> Post([FromBody]Invoice invoice)
        {
            if(User.IsInRole("Readonly"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                response.ReasonPhrase = "User has the Readonly role";
                return ResponseMessage(response);
            }
            // Rest of code
        }
    }
