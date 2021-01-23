    public List<C> GetProperty(List<A> a, List<B> b)
    {
        IEnumerable<IEnumerable<C>> ccc = 
                  b.Select(bb => a.Where(aa => bb.SureName == aa.SName && 
                                                              bb.LastName == aa.LName && 
                                                              bb.Date >= aa.StartDate &&
                                                              bb.Date <= aa.EndDate)
        .Select(cc => new C() { FullName = cc.SName + " " + cc.LName }));
        return ccc.SelectMany(c => c).ToList();
    }
    public class A
    {
        public string SName { get; set; }
        public string LName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class B
    {
        public string SureName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
    }
    public class C
    {
        public string FullName { get; set; }
    }
