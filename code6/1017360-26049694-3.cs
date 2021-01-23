    static void Update(ref string s)
    {
         s = "bar";
    }
    string f = "foo";
    Update(ref f);
    Console.WriteLine(f); // bar
