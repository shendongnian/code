    public List<DateTime> DistinctNoticeDates()
        {
            return (from notices in this.GetTable<Notice>()                    
                    select notices.Notice_DatePlanned.Date).Distinct().OrderByDescending().ToList();
        }
