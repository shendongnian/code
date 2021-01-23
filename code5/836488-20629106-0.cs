    var TripIdStops = new Dictionary<string, List<StopTime>>();
    
    foreach (var time in StopTimes) {
      List<StopTime> list;
    
      if (TripIdStops.TryGetValue(time.TripID, out list))
        list.Add(time);
      else
        TripIdStops.Add(time.TripID, new List<StopTime>() { time });
    }
