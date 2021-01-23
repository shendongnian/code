    static void Main(string[] args)
    {
        string line = "";
        // look for the file "myfile.txt" in application root directory
        using (StreamReader sr = new StreamReader("myfile.txt"))
        {
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        Console.ReadKey();
    }
