    public sealed class EventCountdown
    {
         private readonly LocalDateTime eventTimeUtc;
         private readonly IClock clock;
         // It's probably most convenient to express the event time with the time zone
         // in which it occurs. You could easily change this though.
         public EventCountdown(ZonedDateTime zonedEventTime, IClock clock)
         {
             this.eventTimeUtc = zonedEventTime.WithZone(DateTimeZone.Utc).LocalDateTime;
             this.clock = clock;
         }
         public Period GetPeriodRemaining()
         {
             return Period.Between(clock.Now.InUtc().LocalDateTime, eventTimeUtc);
         }
    }
