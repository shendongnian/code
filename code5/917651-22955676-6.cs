    public List<Class_CourseStartdate> GetClosestStartDate(DateTime coeStartdate)
    {
        return _er.TimeTables
                  .Where(tt => tt.Startdate == coeStartdate)
                  .Select(tt => new { tt.Startdate, tt.TimeTableID })
                  .AsEnumerable() // Do the rest locally
                  .Select(tt => new Class_CourseStartdate 
                  { 
                       CStartdate = tt.Startdate.Value.ToString() ,
                       TimeTableID = tt.TimeTableID 
                  }
                  .ToList();
    }
