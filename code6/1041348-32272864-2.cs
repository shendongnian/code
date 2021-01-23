      public class NavigationService : INavigationService
        {
           //Assuming that you only navigate in the root frame
           Frame navigationFrame = Window.Current.Content as Frame;
           public void Navigate(INavigationPage page)
           {
              navigationFrame.Navigate(page.PageType);
           }
        }
        
    public abstract class NavigationPage<T> : INavigationPage
    {
       public NavigationPage()
       {
          this.PageType = typeof(T);
       }
    }
    
    public class NavigationPage1 : NavigationPage<Page1> { }
    
    
    public class MainPage : Page
    {
       public MainPage()
       {
          //I'll just place the container logic here, but you can place it in a bootstrapper or in app.xaml.cs if you want. 
          var container = new UnityContainer();
          container.RegisterType<INavigationPage, NavigationPage1>();
          container.RegisterType<INavigationService, NavigationService>();
          container.RegisterType<MyViewModel>();
    
          this.DataContext = container.Resolve<MyViewModel>();       
       }
    }
