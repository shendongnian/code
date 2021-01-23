    DateTime from;
    DateTime to;
    var source = from.Month > to.Month ?
                   Enumerable.Range(from, 12).Concat(Enumerable.Range(1, to.Month))
                 : Enumerable.Range(1, 12)
                   .SkipWhile(m => m >= from.Month)
                   .TakeWhile(m => m <= to.Month)
    var monthes = source
         .Select(m => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m));
