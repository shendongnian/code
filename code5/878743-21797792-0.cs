    public static void UpdateEventTime(int ID, int year, int month, int day, int hour, int minute, int duration)
    {
      Event E = (from e in SchedulerDatabase.Events where e.ID == ID select e).Single();
      E.StartDate = new DateTime(year, month, day, hour, minute, 0);
      E.Duration = duration;
      SchedulerDatabase.Entry(E).State = EntityState.Modified;
      SchedulerDatabase.SaveChanges();
    }
