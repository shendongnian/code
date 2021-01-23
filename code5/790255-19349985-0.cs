    public static void Main(String[] args)
    {
        int x;
        Console.WriteLine("Enter the number: ");
        x = Convert.ToInt32(Console.ReadLine());
        if((x != 0) && ((x & (x - 1)) == 0))
            Console.WriteLine("The given number "+x+" is a power of 2");
    }
