    public class BasePage : Page
    {
        public BasePage()
        {
            // instruct StructureMap to resolve dependencies
            ObjectFactory.BuildUp(this);
        }
    }
    public class Default : BasePage
    {
         public ICustomerService customerService { get; set; }
         protected void Page_Load(object sender, EventArgs e)
         {
             // can start using customerService
         }
    }
    public class Login : BasePage
    {
         public IAuthenticationService authenticationService { get; set; }
         protected void Page_Load(object sender, EventArgs e)
         {
             // can start using authenticationService
         }
    }
