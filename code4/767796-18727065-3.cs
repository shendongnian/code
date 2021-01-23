    namespace YourApp.Website.Views
    {
       public abstract class CustomWebViewPage : WebViewPage
       {
          private MenuModel _menu;
          public MenuModel Menu
          {
             get
             {
                try
                {
                    _menu = (MenuModel)ViewBag.Menu;
                }
                catch (Exception)
                {
                    _menu = null;
                }
                return _menu;
             }
          }
       }
       public abstract class CustomWebViewPage<TModel> : WebViewPage<TModel> where TModel : class
       {
          private MenuModel _menu;
          public MenuModel Menu
          {
             get
             {
                try
                {
                    _menu = (MenuModel)ViewBag.Menu;
                }
                catch (Exception)
                {
                    _menu = null;
                }
                return _menu;
             }
          }
       }
    }
