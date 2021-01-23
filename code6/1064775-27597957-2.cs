    // example input values
    var names = TZNames.GetNamesForTimeZone("America/Los_Angeles", "en-US");
    // example output values
    Assert.Equal("Pacific Time", names.Generic);
    Assert.Equal("Pacific Standard Time", names.Standard);
    Assert.Equal("Pacific Daylight Time", names.Daylight);
