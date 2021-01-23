    [Test]
    public void SetListDefaultsShouldResetNamingConventionOfEachListMember()
    {
        var c4 = new Class4
            {
                Z = 100,
                Name4Classes = new List<Class1>
                    {
                        new Class1 {Id = 1, Naming = NamingConvention.Name1},
                        new Class1 {Id = 2, Naming = NamingConvention.Name2},
                        new Class1 {Id = 3, Naming = NamingConvention.Name3}
                    }
            };
        Assert.That(c4.Name4Classes, Is.Not.Empty);
        Assert.That(c4.Name4Classes.Count, Is.EqualTo(3));
        Assert.That(c4.Name4Classes.Any(c => c.Id == 0), Is.False);
        Assert.That(c4.Name4Classes.Any(c => c.Naming == NamingConvention.Name4), Is.False);
        c4.SetListDefaults();
        Assert.That(c4.Name4Classes, Is.Not.Empty);
        Assert.That(c4.Name4Classes.Count, Is.EqualTo(3));
        Assert.That(c4.Name4Classes.Any(c=> c.Id == 0), Is.False);
        Assert.That(c4.Name4Classes.All(c=> c.Naming == NamingConvention.Name4), Is.True);
    }
 
