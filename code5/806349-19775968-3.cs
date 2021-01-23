    public class Datum
    {
        public string Topic = "";
        public string County = "";
        public int Allocated = 0;
        public int NotAllocated = 0;
        public int Total()
        {
            return Allocated + NotAllocated;
        }
    }
