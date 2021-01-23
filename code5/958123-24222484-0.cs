    public class ViewsHandler
    {
            public static Page GetMainPage()
            {
                return new MainView();
            }
     
            public static Page GetUsersListPage()
            {
                return new UsersListView ();
            }
    }
    
    public class MainActivity : AndroidActivity
    {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
     
                // Initializing Xamarin Form
                Xamarin.Forms.Forms.Init (this, bundle);
     
                // create a single NavigationPage wrapping your content
                SetPage (new NavigationPage(ViewsHandler.GetMainPage()));
            }
    }
