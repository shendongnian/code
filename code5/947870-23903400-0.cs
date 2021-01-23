      public bool IsLocationServiceEnabled
      {
       get
       {
         Geolocator locationservice = new Geolocator();
         if (locationservice.LocationStatus == PositionStatus.Disabled)
         {
          return false;
         }
         return true;
       }
      }
