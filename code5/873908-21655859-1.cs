    public class HomeController : Controller
    {
        public async Task<JsonResult> ValidateName(string name)
        {
            //the external validator
            var externalValidators = new Func<string, Task<bool>>[] 
            {
                ExternalValidator1,
                ExternalValidator2,
                ExternalValidator3
            };
            //execute each asynchronously and wait for all to finish
            var externalValidatorTasks = externalValidators.Select(i => i(name)).ToArray();
            await Task.WhenAll(externalValidatorTasks);
            //return "invalid!" if any validation failed
            if (externalValidatorTasks.Any(i => !i.Result))
            {
                return Json("invalid!", JsonRequestBehavior.AllowGet);
            }
            //name is valid
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        //mock external validation
        public Task<bool> ExternalValidator1(string name)
        {
            return Task.FromResult(true);
        }
    }
