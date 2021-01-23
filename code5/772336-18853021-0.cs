    var ord = todays.Select(item => new {Group = DateRange.Today, item.EntryDate})
			  .Union(
			  twoWeeks.Select(item => new {Group = DateRange.LessThanTwoWeeks, item.EntryDate}))
			  .Union(
			  later.Select(item => new {Group = DateRange.MoreThanTwoWeeks, item.EntryDate}))
			  .OrderBy(item => item.Group);
