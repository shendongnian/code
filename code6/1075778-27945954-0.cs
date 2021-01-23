    public void Difference()
    {
        var ageDifferences = from p1 in _persons
                             from p2 in _persons
                             select new
                             {
                                 P1FullName = p1.FirstName + " " + p1.LastName,
                                 P2FullName = p2.FirstName + " " + p2.LastName,
                                 AgeDifference = Math.Abs(p1.Age - p2.Age)
                             };
        foreach (var item in ageDifferences)
        {
            Console.Out.WriteLine("{0} and {1} have {2} years of age difference.", item.P1FullName, item.P2FullName, item.AgeDifference);
        }
        Console.ReadKey();
    }
