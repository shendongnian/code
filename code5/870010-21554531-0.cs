    public abstract class StarSign
    {
        public readonly string Name;
        public readonly DateTime StartDate;
        public readonly DateTime EndDate;
    
        protected StarSign(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    
        public virtual bool Contains(DateTime date)
        {
            date = new DateTime(1, date.Month, date.Year);
            return date >= StartDate && date <= EndDate;
        }
    }
    public class AquariusStarSign : StarSign
    {
        public AquariusStarSign()
            : base("Aquarius", new DateTime(1, 1, 21), new DateTime(1, 2, 18))
        {
        }
    }
    public class CapricornStarSign : StarSign
    {
        public CapricornStarSign()
            : base("Capricorn", new DateTime(1, 12, 21), new DateTime(1, 1, 20))
        {
        }
        public override bool Contains(DateTime date)
        {
            if (date.Month == StartDate.Month)
                return date.Day >= StartDate.Day;
            if (date.Month == EndDate.Month)
                return date.Day <= EndDate.Day;
            return false;
        }
    }
