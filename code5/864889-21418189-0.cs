    public class EventHandlerHelper
    {
      public static GlobalUnload(object sender, RoutedEventArgs e)
      {
        // work
      }
    }
    
    public class Page1
    {
       public void GlobalHandler(object sender, RoutedEventArgs e)
       {
          EventHandlerHelper.GlobalUnload(sender, e);
       }
    }
    
    public class Page2
    {
       public void GlobalHandler(object sender, RoutedEventArgs e)
       {
          EventHandlerHelper.GlobalUnload(sender, e);
       }
    }
