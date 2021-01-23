    List<string> words = new List<string> { "I", "have", "feelings", "meet" };
             
    char ch = 'e';
    var results =
        words
        .Where(w => w.Contains(ch))
        .Select(w => new
        {
            Word = w,
            CharCount = w.Count(c => c.Equals(ch))
        })
        .OrderByDescending(x => x.CharCount)
        .GroupBy(x => x.CharCount)
        .First()
        .Select(x=>x.Word)
        .ToList();
