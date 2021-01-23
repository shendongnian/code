    public static void Main(params string[] args)
    {
        var table = TableParser.Parse(
            @"|| Owner || Action || Status || Comments ||" + Environment.NewLine +
            @"| Bill | Fix the lobby | In Progress | This is easy |" + Environment.NewLine +
            @"| Joe | Fix the bathroom | In Progress | Plumbing \\" + Environment.NewLine +
            @"\\" + Environment.NewLine +
            @"Electric \\" + Environment.NewLine +
            @"\\" + Environment.NewLine +
            @"Painting \\" + Environment.NewLine +
            @"\\" + Environment.NewLine +
            @"\\ |" + Environment.NewLine +
            @"| Scott | Fix the roof | Complete | This is expensive |");
        Console.WriteLine(string.Join(", ", table.Header));
        foreach (var r in table.Rows)
            Console.WriteLine(string.Join(", ", r.Cells.Select(c => string.Join(Environment.NewLine + "\t# ", c))));
    }
