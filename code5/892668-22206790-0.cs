    public class MyViewModel
    {
         public List<Notification> Notifications {get;set;}
    
         //Here!
         public Notification SelectedNotification {get;set;} //INotifyPropertyChanged, etc here
    }
