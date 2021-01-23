     private Notification _selectedNotification;
     public Notification SelectedNotification
     {
         get { return _selectedNotification; }
         set
         {
             _selectedNotification = value;
             NotifyPropertyChange("SelectedNotification");
 
             //here...
             if (value != null)     
                 SelectedFilter = Filters.FirstOrDefault(x => x.Title == value.FilterTitle);
         }
     }
