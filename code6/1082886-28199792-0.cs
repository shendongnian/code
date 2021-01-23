    public class FirstNameViewComponent : ViewComponent
    {
    	private readonly IUserService m_userService;
    
    	public FirstNameViewComponent(IUserService userService)
    	{
    		m_userService = userService;
    	}
    
    	public async Task<IViewComponentResult> InvokeAsync(string userId)
    	{
    		Models.ApplicationUser user = await m_userService.FindUserByIdAsync(userId);
    		return View(user);
    	}
    }
