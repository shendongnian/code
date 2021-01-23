        int numberOfLines;
        if (int.TryParse(Console.ReadLine(), out numberOfLines))
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                string spaces = new String(' ', i);
                string stars = new String('*', (numberOfLines * 2 - 1) - (2 * i));
                Console.WriteLine(spaces + stars + spaces);
            }
        }
        else
        {
            Console.WriteLine("No number entered.");
        }
        Console.Read();
