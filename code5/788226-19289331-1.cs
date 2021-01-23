    public class YourReturnType
    {
        public int ScheduleId {get; set;}
        // other properties
    }
    public YourReturnType Details(int ScheduleID)
    {
        var scheduleItem = db.schedules.FirstOrDefault(f => f.ScheduleId== ScheduleID);
        if (scheduleItem == null) return null;
        return new YourReturnType 
        {
            ScheduleId = scheduleItem.ScheduleId,
            // assign other properties
        };
    }
