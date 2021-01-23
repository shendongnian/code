    public List<DateTime> DistinctNoticeDates()
    {
        return 
            (from notices in this.GetTable<Notice>()
             orderby notices.Notice_DatePlanned descending
             select notices.Notice_DatePlanned.Date)
            .Distinct()
            .ToList();
    }
