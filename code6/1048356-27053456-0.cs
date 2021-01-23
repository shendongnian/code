    // You can specify nationalities, and even assign each one the correct numerical value
    public enum Nationality
    {
        khmer = 0,
        viet = 10,
        thai = 15,
        alien = 20,
    }
    // Then in your method, just cast the selected nationality to an int to get the
    //  numerical value, and call ToString() to get the name
    private void ReportNationality(Nationality nationality)
    {
        Console.WriteLine("he pays {0} and he is from {1}",
                          (int)nationality, nationality.ToString());
        Console.In.ReadLine();
    }
