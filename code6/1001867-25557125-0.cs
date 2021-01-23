    using (StreamReader file = new StreamReader(@"D:\Downloads\testfile.txt"))
    {
        string str = "";
        while ((str = file.ReadLine()) != null || str == null)
        {
            if (str == null)
            {
                Console.WriteLine("Hey! We've already passed the EOF!");
                break;
            }
            Console.WriteLine(str);
        }
    }
