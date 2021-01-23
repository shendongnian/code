    string testingString = "Test1";
    SomeEnum result;
    if (Enum.TryParse(testingString, out result))
    {
        Console.WriteLine("Success");
    }
