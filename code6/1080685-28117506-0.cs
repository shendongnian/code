    using System.Linq;
    public class Range<T>
    {
       T Min { get; private set; }
       T Max { get; private set; }
       
       public Range(T min, T max) 
       {
          Min = min;
          Max = max;
       }
    }
    public static class RangeExtensions
    {
        public static Range<T> GetRange(this List<T> values)
        {
            return new Range<T>(values.Min(), values.Max());
        }
    }
