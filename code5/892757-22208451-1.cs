    List<string> dates = new List<string>();
                dates.Add("1/10/14");
                dates.Add("2/9/14");
                dates.Add("1/15/14");
                dates.Add("2/3/14");
                dates.Add("2/15/14");
    
                var allDates = dates.Select(DateTime.Parse).OrderBy(d=>d).ToList();
                var inputDate = DateTime.Parse("1/13/14");
    
                var closestDate = inputDate >= allDates.Last()
                    ? allDates.Last()
                    : inputDate <= allDates.First()
                        ? allDates.First()
                        : allDates.First(d => d >= inputDate);
