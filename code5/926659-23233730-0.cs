    // We have a DateTime in memory
    DateTime original = new DateTime(635338107839470268);
    // We convert it to a Unix Timestamp
    double unixTimestamp = (original - new DateTime(1970, 1, 1)).TotalSeconds;
    // unixTimestamp is saved somewhere
            
    // User needs to make a 100% precise DateTime from this unix timestamp
    DateTime epochInstance = new DateTime(1970, 1, 1);
    DateTime back = epochInstance.AddTicks((long)(unixTimestamp * TimeSpan.TicksPerSecond));
    // back.Ticks is now 635338107839470268
