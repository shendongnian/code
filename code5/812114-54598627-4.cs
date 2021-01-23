    public class AccountController : ApiController
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager => _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        [Route("api/account"), HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                ModelState.AddModelError(ModelStateConstants.Errors, "Account not found! Try logging out and in again.");
                return BadRequest(ModelState);
            }
            var roles = await UserManager.GetRolesAsync(user.Id);
            var accountModel = new AccountViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Organization = user.Organization.Name,
                Role = string.Join(", ", roles)
            };
            return Ok(accountModel);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }
            }
            base.Dispose(disposing);
        }
    }
