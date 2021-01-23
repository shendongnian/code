    [Test]
    public void RegisterSingleton_GetIstance_ReturnsSameInsanceEachTime()
    {
        SimpleIoc.Default.Register<IRepository, Repository>();
        SimpleIoc.Default.Register<Repository>(() => 
            new Repository("dependency"), "single");
        var result1 = SimpleIoc.Default.GetInstance<IRepository>("single");
        var result2 = SimpleIoc.Default.GetInstance<IRepository>("single");
        Assert.That(result1, Is.SameAs(result2));
    }
