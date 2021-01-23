    public class tables 
    { 
        public virtual DataRow createDataRow(DataTable touse)
        {
           //base implementation
        }
    }
    public class Dog : tables
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public int legs { get; set; }
        public bool tail { get; set; }
        public override DataRow createDataRow(DataTable touse)
        {
           //derived implementation
        }
    }
