    public class DateRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
    
            public bool HasStart
            {
                get { return Start != DateTime.MinValue; }
            }
            public bool IsInRange(DateTime date)
            {
                return (date >= this.Start && date <= this.End);
            }
    
            public List<DateRange> GetAvailableDates(DateRange excludedRange)
            {
                return GetAvailableDates(new List<DateRange>(){excludedRange});
            }
        
            public List<DateRange> GetAvailableDates(List<DateRange> excludedRanges)
            {
                if (excludedRanges == null)
                {
                    return new List<DateRange>() { this };
                }
                var list = new List<DateRange>();
                var aRange = new DateRange();
                var date = this.Start;
                while (date <= this.End)
                {
                    bool isInARange = excludedRanges.Any(er => er.HasStart && er.IsInRange(date));
                    if (!isInARange)
                    {
                        if (!aRange.HasStart)
                        {
                            aRange.Start = date;
                        }
                        aRange.End = date;
                    }
                    else
                    {
                        if (aRange.HasStart)
                        {
                            list.Add(aRange);
                            aRange = new DateRange();
                        }
                    }
                    date = date.AddDays(1);
                }
                if (aRange.HasStart)
                {
                    list.Add(aRange);
                }
                return list;
                }
    }
