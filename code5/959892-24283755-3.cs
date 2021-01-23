    public class TimeslotsFinder
    {
        private readonly IEnumerable<Timeslot> _allTimeslots;
 
        public TimeslotsFinder(IEnumerable<Timeslot> allTimeslots)
        {
            _allTimeslots = allTimeslots;
        }
        
        public Timeslot FindTimeslot(Broadcast broadcast)
        {
            var found = _allTimeslots
                .Select(t => new { Timeslot = t, DurationInTimeslot = DurationInTimeslot(broadcast, t) })
                .Where(x => x.DurationInTimeslot > TimeInHours.Zero)
                .OrderByDescending(x => x.DurationInTimeslot.Value)
                .ThenByDescending(x => x.Timeslot.Start.Value)
                .FirstOrDefault();
            return found == null ? null : found.Timeslot;
        }
        private static TimeInHours DurationInTimeslot(Broadcast broadcast, Timeslot timeslot)
        {
            if (!(InTimeslot(broadcast, timeslot) || CoversEntireTimeslot(broadcast, timeslot))) return TimeInHours.Zero;
            var endToUse = broadcast.EndTime >= timeslot.End
                            ? timeslot.End
                            : broadcast.EndTime;
            var startToUse = broadcast.StartTime <= timeslot.Start
                            ? timeslot.Start
                            : broadcast.StartTime;
            return endToUse.Subtract(startToUse);
        }
        private static bool InTimeslot(Broadcast broadcast, Timeslot timeslot)
        {
            var startsInTimeslot = timeslot.Start <= broadcast.StartTime && broadcast.StartTime < timeslot.End;
            var endsInTimeslot = timeslot.End < broadcast.EndTime && broadcast.EndTime <= timeslot.End;
            return startsInTimeslot || endsInTimeslot;
        }
        private static bool CoversEntireTimeslot(Broadcast broadcast, Timeslot timeslot)
        {
            return broadcast.StartTime <= timeslot.Start && broadcast.EndTime >= timeslot.End;
        }
    }
