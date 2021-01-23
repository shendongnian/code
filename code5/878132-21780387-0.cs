    var content = new List<List<string>>
            {
                new List<string>{ "book", "code", "columnToSum" },
                new List<string>{ "abc", "1", "10" },
                new List<string>{ "abc", "1", "5" },
                new List<string>{ "cde", "1", "6" },
            };
    
    var headers = content.First();
    var result = content.Skip(1)
        .GroupBy(s => new { Code = s[headers.IndexOf("code")], Book = s[headers.IndexOf("book")]})
        .Select(g => new
                 {
                     Book = g.Key.Book,
                     Code = g.Key.Code,
                     Total = g.Select(s => int.Parse(s[headers.IndexOf("columnToSum")])).Sum()
                 });
