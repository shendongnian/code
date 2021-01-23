    public static class ShiftEventExtensions
    {
        public static Tuple<DateTime, DateTime> GetShiftInterval(this ShiftEvent shiftEvent)
        {
            return new Tuple<DateTime, DateTime>(ParseDateTime(shiftEvent.StartDate, shiftEvent.StartTime), ParseDateTime(shiftEvent.EndDate, shiftEvent.EndTime));
        }
        private static DateTime ParseDateTime(string date, string time)
        {
            string text = string.Concat(date, " ", time);
            DateTime result;
            if (DateTime.TryParse(text, out result))
            {
                return result;
            }
            throw new ArgumentException("Invalid DateTime", text);
        }
        public static Shift StartShift(this ShiftEvent shiftEvent, Tuple<DateTime, DateTime> interval)
        {
            return new Shift
            {
                EmployeeId = shiftEvent.EmpId,
                StartOfShiftDate = interval.Item1,
                EndOfShiftDate = interval.Item2,
                ShiftEvents = new List<ShiftEvent> { shiftEvent }
            };
        }
    }
