    class Persons
    {
        //Person object id
        public int id { get; set; }
        //Persons name
        public string name { get; set; }
        //Persons adress
        public string adress { get; set; }
        //Persons age
        public int age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many persons you want to add?: ");
            int count = int.Parse(Console.ReadLine());
            //var newPersons = new List<Persons>(count);
            Persons[] newPersons = new Persons[count];
            for (int i = 0; i < count; i++)
            {
                newPersons[i] = new Persons();
                newPersons[i].id = i+1;
                Console.Write("Write name for person " + (i+1) + "\t");
                newPersons[i].name = Console.ReadLine();
                Console.Write("Write age for person " + (i + 1) + "\t");
                newPersons[i].age = int.Parse(Console.ReadLine());
                Console.Write("Write adress for person " + (i + 1) + "\t");
                newPersons[i].adress = Console.ReadLine();
            }
            Console.WriteLine("\nPersons Name \tAge \tAdresss \n");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(newPersons[i].name + "\t\t" + newPersons[i].age + "\t" + newPersons[i].adress);
            }
            Console.ReadKey();
        }
    }
