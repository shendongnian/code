    [Test]
    public void TestVersions()
    {
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            foreach (var method in type.GetMethods())
            {
                foreach (var customAttribute in method.GetCustomAttributes())
                {
                    var dependent = customAttribute as DependentAttribute;
                    if (dependent != null)
                    {
                        var methodInfo = type.GetMethod(dependent.DependentOnMethod);
                        Assert.That(methodInfo, Is.Not.Null, "Dependent method not found");
                        VersionAttribute version = methodInfo.GetCustomAttributes().OfType<VersionAttribute>().FirstOrDefault();
                        Assert.That(version, Is.Not.Null, "No version attribute on dependent method");
                        Assert.That(dependent.DependentOnVersion, Is.EqualTo(version.Version));
                    }
                }
            }
        }
    }
