      public class PartCount: IComparable<PartCount> {
        public Parts Parts { get; set; }
        public Double Count { get; set; }
        ...
        
        public Boolean CompareTo(PartCount other) {
          if (Object.RefeenceEquals(null, other))
            return 1;
          
          return Count.CompareTo(other.Count);
        }
      }
