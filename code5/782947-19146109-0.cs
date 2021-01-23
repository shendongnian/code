    static void Main(string[] args)
    {
        int newArray = new int[10];
        Console.WriteLine("Please input 10 numbers. Press 'ENTER' after each number.");
        for (int i = 0; i < 10; i++) {
            newArray[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("The values you've entered are:");
        Console.WriteLine(String.Join(", ", newArray));
        Console.ReadLine();
    }
