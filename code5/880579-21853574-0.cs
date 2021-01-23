    var options = StringSplitOptions.RemoveEmptyEntries;
    var lines = text.Split(new [] { Environment.NewLine }, options)
                    .SkipWhile(s => !s.Contains("1 . 1 To Airtel Mobile"))
                    .Skip(1)
                    .TakeWhile(s => !s.Contains("Total"));
