    try
    {
        SomeData data = new SomeData(@"C:\SC.xlsx", "somedata_2014");
        IEnumerable<SomeType> someTypes = someData.GetData();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
