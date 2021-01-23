    if(tripsVM.TripsList != null){
         foreach (Trip trip in tripsVM.TripsList) {
         var a = trip.TripCategory.Name;
         }
    }
    else
    {
       // handle empty list
    }
     private List<Trip> _TripsList;
        
            public List<Trip> TripsList
            {
                get
                {
                _TripsList = new List<Trip>();
                if(TripsService.GetTrips() != null)
                  {
                 _TripsList.add(TripsService.GetTrips());
                  }
                    return _TripsList;
                }
                set { _TripsList = value; }
            }
