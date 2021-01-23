    public class SD
    {
        public Int16 ID { get; set; }
        public Byte MT { get; set; }
        public Byte Data { get; set; }
        public Byte SS { get; set; }
        public DateTime Time { get; set; }
        public class Comparer : IEqualityComparer<SD>
        {
            public bool Equals(SD x, SD y)
            {
                return x.Data == y.Data; // look...here I m using 'Data' field for distinction
            }
            public int GetHashCode(SD obj)
            {
                unchecked  // overflow is fine
                {
                    int hash = 17;
                    hash = hash * 23 + obj.Data.GetHashCode();
                    return hash;
                }
            }
        }
    }
