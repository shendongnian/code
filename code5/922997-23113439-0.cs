     public class Test
     {
        public DateTime Date1;
        public DateTime Date2;
        public string Col_A;
     }
   ...
    List<Test> test = new List<Test>();
    test.GroupBy(t => t.Col_A).Select(group =>
    			              group.OrderByDescending(e => e.Date2).FirstOrDefault())
                              ToList();
