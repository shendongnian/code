    public List<Class_CourseStartdate> GetClosestStartDate(DateTime coeStartdate)
    {
        return _er.TimeTables
                  .Where(tt => tt.Startdate == coeStartdate)
                  .Select(tt => tt.TimeTableID)
                  .AsEnumerable() // Do the rest locally
                  .Select(tid => new Class_CourseStartdate 
                  { 
                       CStartdate = coeStartDate.ToString() ,
                       TimeTableID = tid
                  }
                  .ToList();
    }
