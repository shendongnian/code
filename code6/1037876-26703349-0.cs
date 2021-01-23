    public class Employee : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string DisplayData()
        {
            return string.Format("Name: {0}; Address: {1}", this.Name, this.Address);
        }
    }
