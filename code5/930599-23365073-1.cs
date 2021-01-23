      public AssignTimeSlotViewModel(IDataService dataService)
        {
            // registering the notification 
            MessengerInstance.Register<NotificationMessage>(this, receiveNotification);
        }
       #region Messenger - receivers
        private void receiveNotification(NotificationMessage msg)
        {
            if (msg.Notification == "notifycollection")
            {
                /// Call Database to keep collection updated.
                 // raise propety changed event if neccessary.
                // Do Something
            }
        }
        #endregion
