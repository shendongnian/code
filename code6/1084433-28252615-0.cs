    public class dbStudent
    {
        public int seq;
        public string name;
        public int id;
        public string meritClass;
    }
    
    public class student
    {
        public string name { get; set; }
        public int id { get; set; }
        public string meritClass { get; set; }
    }
    
    public class stdGroup
    {
        public int seqId { get; set; }
        public List<student> students { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var dbStudebts = new List<dbStudent>();
            dbStudebts.Add(new dbStudent { seq = 1, name = "Rajesh", id = 101, meritClass = "B" });
            dbStudebts.Add(new dbStudent { seq = 1, name = "kumar", id = 102, meritClass = "B" });
            dbStudebts.Add(new dbStudent { seq = 1, name = "sandeep", id = 104, meritClass = "A" });
            dbStudebts.Add(new dbStudent { seq = 2, name = "Myur", id = 105, meritClass = "B" });
            dbStudebts.Add(new dbStudent { seq = 2, name = "Bhuvan", id = 106, meritClass = "C" });
            dbStudebts.Add(new dbStudent { seq = 3, name = "Siraz", id = 107, meritClass = "A" });
    
            var result = (from o in dbStudebts
                          group o by new { o.seq } into grouped
                          select new stdGroup()
                          {
                              seqId = grouped.Key.seq,
                              students = grouped.Select(c => new student()
                              {
                                  name = c.name,
                                  id = c.id,
                                  meritClass = c.meritClass
                              }).ToList()
                          }).ToList();
        }
    }
