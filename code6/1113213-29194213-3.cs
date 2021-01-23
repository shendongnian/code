    public class Employees
    {
        public string[] Names { get; set; }
        public string[] Ids { get; set; }
        public Employees()
        {
            this.Names = new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" };
            this.Ids = new[] { "2", "6", "4", "5", "3" };
        }
    }
