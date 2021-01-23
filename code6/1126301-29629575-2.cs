        string input = Console.ReadLine();
        int numberOfLines;
        if (int.TryParse(input, out numberOfLines))
        {
            for (int i = numberOfLines; i >= 1; i--)
            {
                string spaces = new String(' ', (numberOfLines - i));
                string stars = new String('*', (i * 2) - 1);
                Console.WriteLine(spaces + stars + spaces);
            }
            Console.Read();
        }
        else
        {
            Console.WriteLine("No number entered.");
        }
