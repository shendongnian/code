    DateTime startDate = new DateTime(2015, 1, 1);
    DateTime endDate = new DateTime(2015, 1, 30);
    int totalDays = (int)(endDate - startDate).TotalDays + 1;
    availability.Add(new Availability { StartDate = endDate, EndDate = endDate });
    
    var result = from x in Enumerable.Range(0, totalDays)
                let d = startDate.AddDays(x)
                from a in availability.Select((v, i) => new { Value = v, Index = i })
                where (a.Index == availability.Count - 1 ? 
                         d <= a.Value.StartDate : d < a.Value.StartDate)
                && (a.Index != 0 ? d > availability[a.Index - 1].EndDate : true)
                group new { d, a } by a.Value.StartDate into g
                select new
                {
                     AvailableDates = String.Format("{0} - {1}",g.Min(x => x.d),
                                                                g.Max(x => x.d))
                };
