    public static void Main(params string[] args)
    {
            var wikiLine = @"|| Owner|| Action || Status || Comments || | Bill\\ | fix the lobby |In Progress | This is eary| | Joe\\ |fix the bathroom\\ | In progress| plumbing  \\Electric \\Painting \\ \\ | | Scott \\ | fix the roof \\ | Complete | this is expensive|";
            var table = TableParser.Parse(wikiLine);
            Console.WriteLine(string.Join(", ", table.Header));
            foreach (var r in table.Rows)
                Console.WriteLine(string.Join(", ", r.Cells.Select(c => string.Join(Environment.NewLine + "\t# ", c))));
    }
