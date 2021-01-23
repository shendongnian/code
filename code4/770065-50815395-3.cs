    namespace WebApi.Controllers
    {
        [Produces("application/json")]
        [Route("api/Accounts")]
        public class AccountsController : Controller
        {
            // GET: api/Transaction
            [HttpGet]
            public JsonResult Get()
            {
                List<Account> lstAccounts;
    
                lstAccounts = AccountsFacade.GetAll();
    
                //This line is different !! 
                return new JsonConvert.SerializeObject(lstAccounts);
            }
        }
    }
