    class Program
    {
        static void Main(string[] args)
        {
            Employee root = new Employee(1.ToString(), "root");
            var e2 = root.AddChildOrg(2.ToString(), "2 second level");
            var e3 = e2.AddChildOrg(3.ToString(), "3 third level");
            var e1 = root.AddChildOrg(4.ToString(), "4 second level");
            var e5 = e1.AddChildOrg(5.ToString(), "5 third level");
            Console.WriteLine("Id 3 -> {0}", Employee.GetNode(root, "3").Name);
            Console.WriteLine("Id 1 -> {0}", Employee.GetNode(root, "1").Name);
            Console.WriteLine("Id 5 -> {0}", Employee.GetNode(root, "5").Name);
            Console.ReadKey();
        }
    }
