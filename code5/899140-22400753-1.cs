    [Test]
    public void BeginsWith_test()
    {
        const string string1 = "\"ʿAbdul-Baha'\"^^mso:text@de";
        const string string2 = "\"Abdul-Baha'\"^^mso:text@de";
        var chars1 = string1.ToCharArray();
        var chars2 = string2.ToCharArray();
        Assert.That(chars1[0], Is.EqualTo('"'));
        Assert.That(chars2[0], Is.EqualTo('"'));
        Assert.That(string1.StartsWith("\"", StringComparison.InvariantCulture), Is.False);
        Assert.That(string1.StartsWith("\"", StringComparison.CurrentCulture), Is.False);
        Assert.That(string1.StartsWith("\"", StringComparison.Ordinal), Is.True); // Works
        Assert.That(string2.StartsWith("\""), Is.True);
    }
