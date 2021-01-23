    [Test]
    public void RegisterSingletonWithDependentClass_GetIstance_ReturnsSame()
    {
        SimpleIoc.Default.Register<IRepository, Repository>();
        SimpleIoc.Default.Register<SomeService>();
        SimpleIoc.Default.Register<Repository>(() => 
            new Repository(
                SimpleIoc.Default.GetInstance<SomeService>())
                , "single");
        var result1 = SimpleIoc.Default.GetInstance<IRepository>("single");
        var result2 = SimpleIoc.Default.GetInstance<IRepository>("single");
        Assert.That(result1, Is.SameAs(result2));
    }
