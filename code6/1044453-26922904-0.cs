    public class ModelAddress
    {
        public String Line1 { get; set; }
        public String Line2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
    
    }
    
    public class ViewModelAddress : ModelAddress
    {
        public WhizzyWhig WW { get; set; }
        public FancyWhatzitUIProperty FwUp { get; set; }
    
        public ViewModelAddress(ModelAddress copy)
        {
            this.Line1 = copy.Line1;
            this.Line2 = copy.Line2;
            this.City = copy.City;
            this.State = copy.State;
            this.Zip = copy.Zip;
        }
    }
