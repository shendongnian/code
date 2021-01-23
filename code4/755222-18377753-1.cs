    static void dirSearch(string dir)
    {
        foreach (string item in Directory.GetDirectories(dir))
        {
            Console.WriteLine(item);
            try
            {
                foreach (string str in Directory.GetFiles(item))
                {
                    Console.WriteLine("\t" + str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
