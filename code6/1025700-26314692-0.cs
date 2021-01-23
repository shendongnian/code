     static void Main(string[] args)
        {
            Console.WriteLine("This program allows you to write names to a list,");
            List<string> nameList = new List<string>();
            string name = " ";
            Console.WriteLine("Enter names then press enter to add them to the list of names! if you wish to exit simple type exit.");
            while (name.ToLower() != "exit")
            {
                Console.WriteLine("Enter Name: ");
                name = Console.ReadLine();
                nameList.Add(name);
            }
            string[] nameArray = nameList.ToArray();
    
            Console.ReadLine();
        }
