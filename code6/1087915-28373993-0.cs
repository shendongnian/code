    public class CompoundObject
    {
        public List<Regions> Regions { get; set; }
        public List<Museums> Museums { get; set; }
    }
    var example = new CompoundObject { Regions = reg, Museums = mus };
