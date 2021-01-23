    public class Employee
    {
        public int IdNum { get; set; }
        public string FlName { get; set; }
        public double Annual { get; set; }
        public Employee(int id, string flname, double annual = 0.0)
        {
            IdNum = id;
            FlName = flname;
            Annual = annual;
        }
        
        public override string ToString()
        {
           return (Convert.ToString(IdNum) + "  " + FlName + "  " + Convert.ToString(Annual));
        }
    }
