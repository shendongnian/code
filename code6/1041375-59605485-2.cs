    public static class NavigationMap
    {
        public static void RegisterNavigation<TModel, TView>(this ContainerBuilder builder)
            where TModel : PageViewModel
            where TView : Page
        {
            builder.RegisterInstance(new NavigationMap<TModel, TView>())
                .As<INavigationMap<TModel>>()
                .SingleInstance();
        }
    }
         builder.RegisterNavigation<MyViewModel, MyView>();
   
    public class UserAuthenticationModel : PageViewModel
    {
        protected override void OnNavigationCompleted()
        {
            // UI is visible and ready
            // navigate to somewhere else
            Navigation.Navigate<MyNextViewModel>();
        }
    }
