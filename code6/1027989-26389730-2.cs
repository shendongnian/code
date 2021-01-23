    string s = "*keyName:branding-SLES Relocations:(not relocatable)*keyOpenEnd";
    string desired = "{\"Name:branding-SLES Relocations:(not relocatable)\":";
    Regex r = new Regex(@"\*key(.*)\*keyOpenEnd", RegexOptions.Compiled);
    Stopwatch watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < 100000; i++)
    {
        var n = r.Replace(s, "{\"$1\":");
        Assert.AreEqual(desired, n);
    }
    watch.Stop();
    Console.WriteLine("RegEx Total: {0}", watch.Elapsed);
    watch.Reset();
    watch.Start();
    for (int i = 0; i < 100000; i++)
    {
        var n = s.Replace("*keyOpenEnd", "\":").Replace("*key", "{\"");
        Assert.AreEqual(desired, n);
    }
    watch.Stop();
    Console.WriteLine("String Replace Total: {0}", watch.Elapsed);
