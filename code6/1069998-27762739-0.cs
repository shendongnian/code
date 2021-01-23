    static void Main(string[] args)
    {
        int id;
        string name;
        float duration;
        float price;
        do
        {
        Console.WriteLine("Enter the movie id");
        }
        while(!int.TryParse (Console.ReadLine(), out id));
        Console.WriteLine("Enter the movie name");
        name = Console.ReadLine();
        do
        {
            Console.WriteLine("Enter the movie duration");
        }
        while (!float.TryParse(Console.ReadLine(), out duration));
        do
        {
            Console.WriteLine("Enter the movie price");
        }
        while (!float.TryParse(Console.ReadLine(), out price));
        Console.WriteLine("{0}, {1}, {2}, {3}", id, name, duration, price);
        Console.ReadKey();
    }
