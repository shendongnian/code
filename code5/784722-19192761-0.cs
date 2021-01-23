    static void Main(string[] args)
    {
       var numbers = new List<int>();
       for (var i = 1; i <= 3; i++)
       {
           Console.WriteLine("Please enter your computer marks");
           numbers.Add(int.Parse(Console.ReadLine()));
       }
       
       Console.WriteLine(string.Format("Maximum value: {0}", numbers.Max());
       Console.ReadKey();
    }
