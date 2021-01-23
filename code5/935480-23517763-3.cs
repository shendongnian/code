    static void Main(string[] args)
    {
        String OfficeVersion = new VersionFinder().GetOfficeVersion();
        Console.WriteLine("OfficeVersion: " + OfficeVersion);
        Console.ReadLine();
    }
