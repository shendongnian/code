    using NodaTime;
        DateTime EventDT;
        LocalDateTime LocalizedEventDT;
        Period TimeLeft; 
        public EventCountdown()
        {
            // Start with a date and time
            EventDT = Convert.ToDateTime("09/12/2016 10:00AM");
            // Localize it
            LocalizedEventDT = new LocalDateTime(
                EventDT.Year, EventDT.Month, 
                EventDT.Day, EventDT.Hour, 
                EventDT.Minute, 0);
        }
        // find out how much time is between now and the future date
        public Period GetPeriodRemaining()
        {
            DateTime dt_Now = DateTime.Now;
     
            return Period.Between(new LocalDateTime(
                dt_Now.Year, dt_Now.Month, dt_Now.Day, dt_Now.Hour, 
                dt_Now.Minute, dt_Now.Second), LocalizedEventDT);
        }
