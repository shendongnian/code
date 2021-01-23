    public class Person
    {
        public string Name { get; set; }
    }
    static void Main(string[] args)
    {
        Console.Write("How many persons you want to add?: ");
        int p = int.Parse(Console.ReadLine());
        var people = new List<Person>();
        for (int i = 0; i < p; i++)
        {
            // Here you can give each person a custom name based on a number
            people.Add(new Person { Name = "Person #" + (i + 1) });
        }
    }
