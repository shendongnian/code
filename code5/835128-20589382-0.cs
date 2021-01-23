    IList<IWebElement> options = soc.Options;
    Assert.Equals(options.Count, drop.Length);
    
    foreach (IWebElelent option in options)
    {
        Console.Write(" " + drop[i]);
        Assert.IsTrue(drop.Contains(option.Text));
    }
