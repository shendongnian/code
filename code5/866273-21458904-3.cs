    [Test]
    public void CreateNonGeneric_ReturnsSameInstance1()
    {
        SimpleIoc.Default.Register<Repository>();
        var result1 = SimpleIoc.Default.GetInstance<Repository>();
        var result2 = SimpleIoc.Default.GetInstance<Repository>();
        Assert.That(result1, Is.SameAs(result2));
    }
    [Test]
    public void CreateNonGeneric_ReturnsSameInstance2()
    {
        SimpleIoc.Default.Register<IRepository, Repository>();
        var result1 = SimpleIoc.Default.GetInstance<IRepository>();
        var result2 = SimpleIoc.Default.GetInstance<IRepository>();
        Assert.That(result1, Is.SameAs(result2));
    }
    [Test]
    public void CreateNonGeneric_ReturnsSameInstance3()
    {
        SimpleIoc.Default.Register<Repository>();
        var result1 = SimpleIoc.Default.GetInstance<Repository>("alwaysthesame");
        var result2 = SimpleIoc.Default.GetInstance<Repository>("alwaysthesame");
        Assert.That(result1, Is.SameAs(result2));
    }
