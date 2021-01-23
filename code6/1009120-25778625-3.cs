    var inputs = new[] { "Mary Brown", "Sally Green", "Lucy Purple" };
    var searchText = "Mary Brown is a nice person";
    var words = searchText.Split(' ');
    var result = inputs.Select(text => new
        {
            MatchCount = text.Split(' ')
                .Sum(input => words.Where(word => word == input).Count()),
            Text = text
        })
        .OrderByDescending(a => a.MatchCount)
        .Select(a => a.Text)
        .DefaultIfEmpty()        
        .First();
