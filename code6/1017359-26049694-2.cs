    static void Update(string s)
    {
         s = "bar";
    }
    string f = "foo";
    Update(f);
    Console.WriteLine(f); // foo
