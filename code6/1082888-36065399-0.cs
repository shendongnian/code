    public interface IUserProfileLoader
    {
        Task<ApplicationUser> GetCurrentApplicationUser(ClaimsPrincipal user);
    }
    public class UserServices : IUserProfileLoader
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser _CurrentUser;
        public UserServices([FromServices]UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser> GetCurrentApplicationUser(ClaimsPrincipal user)
        {
            if (_CurrentUser == null)
            {
                _CurrentUser = await _userManager.FindByIdAsync(user.GetUserId());
            }
            return _CurrentUser;
        }
    }
