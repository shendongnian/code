    public class Customer
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name; 
        }
    }
    public class CustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    void Print()
    {
       List<Customer> l1 = new List<Customer>();
       l1.Add(new Customer() {  Name="aa"});
       l1.Add(new Customer() { Name = "cc" });
       l1.Add(new Customer() { Name = "bb" });
       List<Customer> l2 = new List<Customer>(l1);
       l2.Sort(new CustomerComparer());
       foreach (var item in l1)
            Console.WriteLine(item);
            
       Console.WriteLine();
       foreach (var item in l2)
            Console.WriteLine(item);
           
       Console.ReadLine();
