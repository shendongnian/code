    static void Main(string[] args)
    {
        string[] colors = { "green", "brown", "blue", "red" };
        var list = new List<string>(colors); // <string>
        IEnumerable query = list.Where(c => c.Length == 3); // "Length", not "length"
        list.Remove("red");
        Console.WriteLine(query.Count());
    }
