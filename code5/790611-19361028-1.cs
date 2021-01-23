    public class Customer
    {
        public string Name {get; set;}
        public List<Site> Sites { get; set; }
        public Customer()
        {
            Sites = new List<Site>();
        }
    }
    public class Site
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Site(string sitename, string siteaddress, string tel)
        {
            Name = sitename;
            Adress = siteaddress;
            PhoneNumber = tel;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Name = "Max Hammer Ltd";
            string address = string.Join(Environment.NewLine, new []{"1 Edgerail Close", "Greenbushes", "Bluehill"
                 , "Surrey", "RH0 6LD"});
            Site surreyOffice = new Site("Surrey Office", address, "01737 000000");
            address = string.Join(Environment.NewLine, new[]{"1 Edgerail Close", "Greenbushes", "Bluehill"
                    , "Surrey", "RH0 6LD"});
            Site brixtonOffice = new Site("Brixton Office", address, "020 7101 3333");
            customer.Sites.Add(surreyOffice);
            customer.Sites.Add(brixtonOffice);
            Console.WriteLine(customer.Name);
            foreach (Site site in customer.Sites)
            {
                Console.WriteLine(site.Name);
                Console.WriteLine(site.Adress);
                Console.WriteLine(site.PhoneNumber);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
