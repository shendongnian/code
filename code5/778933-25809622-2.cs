      public class CustomerViewModel
     {
                public CustomerViewModel()
                {
                    SessionInfo.Instance.eventHanlder.GetEvent<Notifications>().Subscribe(OnReceivedNotification);
                
                }
    
            //Handling the notification 
        public void OnReceivedNotification(string itemId)
            {
                Debug.WriteLine("Item Id is :" + itemId);
               
            }
    
    
      }
