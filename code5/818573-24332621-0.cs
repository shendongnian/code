    [RoutePrefix("api/v{version}")]
    public class BankAccountsController : ApiController
    {
        [HttpGet]
        [Route("bank-accounts")]
        public HttpResponseMessage GetBankAccounts(string version)
        {
            //...
        }
    }
