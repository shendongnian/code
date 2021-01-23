    public List<string> GetTimeTableIdsForStartDate(DateTime coeStartdate)
    {
        return _er.TimeTables
                  .Where(tt => tt.Startdate == coeStartdate)
                  .Select(tt => tt.TimeTableID)
                  .ToList();
    }
