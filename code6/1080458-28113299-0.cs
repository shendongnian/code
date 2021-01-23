    public List<Test> DemoToTestProjection(List<Demo> demos)
    {
        var projectedTests = new List<Test>();
        for each (var demo in demos)
        {
            projectedTests.Add(new Test
            {
                Name = l.Name,
                Val = int.Parse(l.Val)
            });
        }
        return projectedTests;
    }
    public void DoSomething()
    {
        var demos = new List<Demo>({...});
        try
        {
            var result = DemoToTestProjection(demos);
        }
        catch(Exception ex)
        {
            // How would you expect to get information about the specific
            // `Demo` you were having an issue with here?
        }
    }
