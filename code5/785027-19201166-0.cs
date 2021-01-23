    static void Main(string[] args)
    {
        string filename = @"E:\Practice\C#\MySchedular.txt";
        string fileContent;
        Console.WriteLine("Enter the date to search appointment in (dd/mm/yyyy) format");
        string date = Console.ReadLine();
        using (StreamReader sr = new StreamReader(filename))
        {
            fileContent = sr.ReadToEnd();
        }
        if (fileContent.Contains(date))
        {
            string[] apts = fileContent.Split('\n').Where(x => x.Contains(date)).ToArray();
            foreach (string apt in apts)
            {
                Console.WriteLine("\n**Appointment Details**");
                Console.WriteLine("{0}", apt);
                Console.WriteLine("\n");
            }
        }
        else
        {
            Console.WriteLine("No appointment details found for the entered date");
        }
        Console.Read();
    }
