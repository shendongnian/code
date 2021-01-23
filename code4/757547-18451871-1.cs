    // select all sub-strings of each TokenList into 1 big IEnumerable.
    var query = pro.TokenList.SelectMany(item => item);
    // display all strings while iterating the query.
    foreach(var s in query)
        Console.WriteLine(s);
