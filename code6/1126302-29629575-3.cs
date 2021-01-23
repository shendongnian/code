        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = numberOfLines; i >= 1; i--)
        {
            string spaces = new String(' ', (numberOfLines - i));
            string stars = new String('*', (i * 2) - 1);
            Console.WriteLine(spaces + stars + spaces);
        }
        Console.Read();
