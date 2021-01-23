    Database db = DatabaseWrapper.GetDatabase();
    DateTime dd = e.ParsedData.Date;
    List<Flight> todaysflights = new List<Flight>();
    foreach (var a in db.Flights.GetList()){
        if(a.ScheduleDateTime.Date() == dd){
            todaysflights.Add(a);
        }
    }
    
