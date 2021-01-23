    static void Main(string[] args)
    {
        Console.WriteLine("What is the Size of the Array?");
        string inputArray = Console.ReadLine();
        int userArray = Convert.ToInt32(inputArray);
        int[] userArrayinputed = new int[userArray];
        for (int index = 0; index < userArray; index++)
        {
            Console.WriteLine("Number " + index + " Value is:");
            //note you will get an error here if you try and parse something that isn't an interger
            userArrayinputed[index] = int.Parse(Console.ReadLine());
        }
        for (int index = userArray -1; index >= 0; index--)
        {
            Console.WriteLine(userArrayinputed[index]);
            
        }
        Console.ReadLine();
    }
