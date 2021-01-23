    public class DME
    {
        public DateTime DateActivation { get; set; }               // Is always set
        public DateTime? DateDeactivation { get; set; }   // Set or Null
    }
    public ActionResult ActiveRecordsInTimeFrame(string DateStart, string DateFinish)
    {
        var model = GetActiveRecordsBetweenDates(
                        Convert.ToDateTime(DateStart), 
                        Convert.ToDateTime(DateFinish)).ToList();
        ...
    }
    ...
    private IQueryble<IEnumerable<int>> 
            GetActiveRecordsBetweenDates(DateTime dtStart, DateTime? dtEnd) 
    {
        if(dtEnd.HasValue)
        {
            // both dates provided
            return from db in db.DMEs
                   where d.DateActivation >= dtStart &&
                         d.DateActivation <= dtEnd
                   select db.Id;
        }
        // no end date
        return from db in db.DMEs
               where d.DateActivation >= dtStart
               select db.Id;
    }
