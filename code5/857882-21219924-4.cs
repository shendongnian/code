    public class Address
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public static Addess FromLine(string line)
        {
            var a = new Address();
            string[] parts = line.Split('@');
            a.ID = Int32.Parse(parts[0]);
            a.FirstName = parts[3];
            a.LastName = parts[4];
            a.City = parts[8];
            return a;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}, {3}", FirstName, LastName, City);
        }
    }
