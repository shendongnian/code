    public class IntegerList
    {
        public int IntegerListID { get; set; }
        public string Direction { get; set; }
        public long Performance { get; set; }
        public virtual ICollection<Integer> Integers { get; set; }
    
        public IntegerList()
        {
          Integers =new List<Integer>();
        }
    }
