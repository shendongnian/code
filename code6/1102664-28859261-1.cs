    IntervalCollection Intervals = new IntervalCollection();
    string EncodeText  = "";
    Intervals.Add(new Interval { Name = "a", Min = 3, Max = 13 });
    Intervals.Add(new Interval { Name = "b", Min = 11, Max = 20 });
    Intervals.Add(new Interval { Name = "c", Min = 16, Max = 21 });
    Intervals.Add( "z", 200, 250 }); //you can add item in this way too.
    EncodeText = Intervals.Encode(6,8,12,13,17,20);
