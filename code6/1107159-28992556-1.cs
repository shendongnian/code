    private void methodDictionary()
    {
        var infos = new Dictionary<string, MethodInfo>();
        infos.Add("a", this.GetType().GetMethod("a"));
        infos.Add("b", this.GetType().GetMethod("b"));
    
        MethodInfo a = infos["a"];
        a.Invoke(this, new[] { "a1", "b1" });
    
        MethodInfo b = infos["b"];
        b.Invoke(this, new object[] { 10, "b1", 2.056 });
    }
    
    public void a(string a, string b)
    {
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
    
    public void b(int a, string b, double c)
    {
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
    }
