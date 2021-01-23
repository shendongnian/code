    public class UserController : ApiController
    {
        private readonly IUrlProvider urlProvider;
        public UserController(IUrlProvider urlProvider)
        {
            this.urlProvider = urlProvider;
        }
        public string Get()
        {
            this.urlProvider.UriFor<HomeController>(c => c.SomeFancyAction());
        }
    }
