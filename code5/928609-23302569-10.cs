    [Test]
    public void TestDefaultValueAttribute()
    {
        //Class2 have Name2 as the default value for the Naming property
        var c2 = new Class2();
        Assert.That(c2,Is.Not.Null);
        Assert.That(c2.Name2Class, Is.Not.Null);
        Assert.That(c2.Name2Class.Naming, Is.EqualTo(NamingConvention.Name2));
        //Class3 have Name3 as the default value for the Naming Property
        var c3 = new Class3();
        Assert.That(c3, Is.Not.Null);
        Assert.That(c3.Name3Class, Is.Not.Null);
        Assert.That(c3.Name3Class.Naming, Is.EqualTo(NamingConvention.Name3));
        //wipes out other properties of the Class1 attribute.
        // to demonstrate, set properties to something other than the default then call
        // SetDefaults again.
        c3.Name3Class.Naming = NamingConvention.Name1;
        c3.Name3Class.Id = 10;
        c3.SetDefaults();
        Assert.That(c3.Name3Class.Id, Is.EqualTo(0));
        Assert.That(c3.Name3Class.Naming, Is.EqualTo(NamingConvention.Name3));
    }
