    var = list.Select(l => MapToTest(l))
              .ToList();
    public Test MapToTest(Demo demo)
    {
        try
        {
            Test test = new Test {...};
        }
        catch(Exception ex)
        {
            LogStuffAboutDemo(demo);
        }
    }
