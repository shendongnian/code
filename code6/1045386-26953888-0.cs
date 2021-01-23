    static void Main(string[] args)
    {
        Console.Write("What is the base of the triangle? ");
        int baseOfTriangle = int.Parse(Console.ReadLine());
        Console.Write("What is your height of the triangle? ");
        int heightOfTriangle = int.Parse(Console.ReadLine());
        Console.WriteLine("The area of the triangle is {0}", (baseOfTriangle * heightOfTriangle) / 2);
        Console.ReadLine();
    }
