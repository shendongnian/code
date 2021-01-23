    try
    {
        ObjectGenerator Gen = new ObjectGenerator();
        object obj = Gen.GenerateObject(typeof(Test));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
