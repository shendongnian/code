    class ListHeaderData
    {
        public DateTime EntryDate;
        public int DateDifferenceFromToday
        {
            get
            {
                TimeSpan difference = DateTime.Today - EntryDate.Date;
                if (difference.TotalDays == 0)//today
                {
                    return 1;
                }
                else if (difference.TotalDays <= 14)//less than 2 weeks
                {
                    return 2;
                }
                else
                {
                    return 3;//something else
                }
            }
        }
    }
