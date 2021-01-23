    public class YearMonth : IEquatable<YearMonth>
    {
        public readonly int Year;
        public readonly int Month;
        public YearMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}", Year, Month);
        }
        public bool Equals(YearMonth other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Month == other.Month && Year == other.Year;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YearMonth)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Month * 397) ^ Year;
            }
        }
        public static bool operator ==(YearMonth left, YearMonth right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(YearMonth left, YearMonth right)
        {
            return !Equals(left, right);
        }
    }
