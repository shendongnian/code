    DateTime.Now.Add(  1, TimeUnits.Week); // add a week
    DateTime.Now.Add( 42, TimeUnits.Week); // add multiple weeks
    DateTime.Now.Add(- 1, TimeUnits.Week); // subtract a week
    DateTime.Now.Add(-42, TimeUnits.Week); // subtract multiple weeks
    DateTime.Now.Add(  0, TimeUnits.Week); // return `current`
    //etc...
