        string inputArray = Console.ReadLine();
        int userArray = Convert.ToInt32(inputArray);
        int[] userArrayinputed = new int[userArray];
        for (int index = 0; index < userArray; index++)
        {
            Console.WriteLine("Number " + index+ " Value is:");
            userArrayinputed[index] = int.Parse(Console.ReadLine());
        }
        for (int index = 0; index < userArray; index++)
        {
            Console.WriteLine(userArrayinputed[index]);
            Console.ReadLine();
        }
