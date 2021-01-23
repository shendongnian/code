    [Test]
    public void ShouldNotReferenceServiceProjectDirectly()
    {
        var assembly = GetAssemblyContainingType<RouteConfig>();
        var referencedAssemblies = assembly.GetReferencedAssemblies();
        var implementationAssembly = referencedAssemblies
            .FirstOrDefault(x => x.Name == "MyNamespace.Service");
        var interfaceAssembly = assembly.GetReferencedAssemblies()
            .FirstOrDefault(x => x.Name == "MyNamespace.Service.Interfaces");
        Assert.That(implementationAssembly, Is.Null);
        Assert.That(interfaceAssembly, Is.Not.Null);
    }
    private static Assembly GetAssemblyContainingType<T>()
    {
        return (typeof(T).Assembly);
    }
