    public class NavigationServiceHelper : NavigationService
    {
        public NavigationServiceHelper()
        {
            this.Configure("Page1", typeof(View.Page1));
            this.Configure("Page2", typeof(View.Page2));
        }
    }
