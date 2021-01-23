    class ListHeaderData
    {
        public DateTime EntryDate;
        public DateRange DateDifferenceFromToday
        {
            get
            {
                //I think for this version no comments needed names are self explanatory
                TimeSpan difference = DateTime.Today - EntryDate.Date;
                if (difference.TotalDays == 0)
                {
                    return DateRange.Today;
                }
                else if (difference.TotalDays <= 14)
                {
                    return DateRange.LessThanTwoWeeks;
                }
                else
                {
                    return DateRange.MoreThanTwoWeeks;
                }
            }
        }
    }
    enum DateRange
    { 
        None = 0,
        Today = 1,
        LessThanTwoWeeks = 2,
        MoreThanTwoWeeks = 3
    }
