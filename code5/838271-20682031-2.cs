    var firstList = new List<VT> {
       new VT { Value = "Violet", Timestamp = new DateTime(2013, 12, 18, 20, 26, 0) },
       new VT { Value = "Red", Timestamp = new DateTime(2013, 12, 18, 20, 30, 0) },
       new VT { Value = "Orange", Timestamp = new DateTime(2013, 12, 18, 20, 40, 0) },
       new VT { Value = "Yellow", Timestamp = new DateTime(2013, 12, 18, 20, 50, 0) }
    }.ToObservable();
	
	var secondList = firstList.Skip(1);
	
	var combined = firstList.Zip(secondList, (first, second) => new  {
                                                     EventID = first.Value, 
                                                     StartTime = first.Timestamp, 
                                                     EndTime = second.Timestamp, 
                                                     Duration = (second.Timestamp - first.Timestamp).TotalSeconds});
	
	combined.Subscribe();
