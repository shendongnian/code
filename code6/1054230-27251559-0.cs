    DateTime today = DateTime.Today;
    DateTime startUtc = today.ToUniversalTime();
    DateTime endUtc = today.AddDays(1).ToUniversalTime();
    var result = queryableDate.Where(s => startUtc <= s.Created &&
                                          s.Created < endUtc);
