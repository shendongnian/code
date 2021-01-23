    //variables used in both examples
    var start = TimeSpan.FromHours(11);
    var end = TimeSpan.FromHours(21).Add(TimeSpan.FromMinutes(30));
	MoreEnumerable.Generate(start, span => span.Add(TimeSpan.FromMinutes(30)))
				  .TakeWhile(span => span <= end)
