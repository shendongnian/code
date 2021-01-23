     public class SettingsViewModel
     {
      public List<NotificationViewModel> ListNotification { get; set; }
      public string TestValue { get; set; }
      public SettingsViewModel()
      {
        ListNotification = new List<NotificationViewModel>();
        TestValue = "Test";   
      }
     }
