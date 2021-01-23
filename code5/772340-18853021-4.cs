    var ord = todays.Select(item => new {Group = DateRange.Today, Count=todays.Count()})
			  .Union(
			  twoWeeks.Select(item => new {Group = DateRange.LessThanTwoWeeks, Count=twoWeeks.Count()}))
			  .Union(
			  later.Select(item => new {Group = DateRange.MoreThanTwoWeeks, Count=later.Count()}))
			  .OrderBy(item => item.Group);
