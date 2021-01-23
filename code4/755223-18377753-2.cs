    static void dirSearch(string dir)
    {
        Console.WriteLine(dir);
        foreach (string item in Directory.GetDirectories(dir))
        {
            try
            {
                dirSearch(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        foreach (string str in Directory.GetFiles(item))
        {
            Console.WriteLine("\t" + str);
        }
    }
