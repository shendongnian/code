    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {    
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                bool isAdministrator = User.IsInRole("Administrators");
            }
        }
    }
