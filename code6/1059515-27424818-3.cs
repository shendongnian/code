    static void Main(string[] args)
        {
            var root = new Employee(1.ToString(), "root");
            var e1 = new Employee(2.ToString(), "1 second level");
            var e2 = new Employee(3.ToString(), "2 third level");
            var e3 = new Employee(4.ToString(), "3 second level");
            var e4 = new Employee(5.ToString(), "4 third level");
            e3.ChildOrg.Add(e4);
            e2.ChildOrg.Add(e3);
            e1.ChildOrg.Add(e2);
            root.ChildOrg.Add(e1);
            Console.WriteLine("Id 3 -> {0}", Employee.GetNode(root, "3").Name);
            Console.WriteLine("Id 1 -> {0}", Employee.GetNode(root, "1").Name);
            Console.WriteLine("Id 5 -> {0}", Employee.GetNode(root, "5").Name);
            Console.ReadKey();
        }
