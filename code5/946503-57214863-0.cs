    var sw0 = Stopwatch.StartNew();
    sw0.Stop();
    
    var sw1 = Stopwatch.StartNew();
    var t1 = System.Web.Helpers.Json.Encode(true);
    var e1 = sw1.ElapsedMilliseconds; // returns 6-9
    
    var sw2 = Stopwatch.StartNew();
    var t2 = true.ToString().ToLower();
    var e2 = sw2.ElapsedMilliseconds; // returns 0
