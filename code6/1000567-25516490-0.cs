    public class FooController : Controller
    {
        private readonly IMembershipService MembershipService;
    
        public FooController( IMembershipService membershipService )
        {
            MembershipService = membershipService;
        }
    
        [Authorize( Roles = "Administrator" )]
        public ActionResult DoSomething()
        {
            var user = MembershipService.GetUser( User.Identity.Name );
    
            // etc...
        }
    }
