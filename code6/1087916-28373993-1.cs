    public class CompoundObject
    {
        public List<Regions> Regions { get; set; }
        public List<Museums> Museums { get; set; }
        public CompoundObject(List<Regions> regions, List<Museums> museums)
        {
            Regions = regions;
            Museums = Museums;
        }
    }
    var example = new CompoundObject(reg, mus);
