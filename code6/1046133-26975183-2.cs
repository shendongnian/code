    public class UIHelper
    {
       /* Some other methods */
       public static TaskScheduler GetUITaskScheduler()
       {
          TaskScheduler scheduler = null;
          Application.Current.Dispatcher.Invoke(() =>
          {
             scheduler = TaskScheduler.FromCurrentSynchronizationContext();
          });
          return scheduler;
       }    
    }
