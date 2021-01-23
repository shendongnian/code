    // Based on OPs comment: preserve empty non-quoted entries.
    var splitOptions = StringSplitOptions.None;
    //change to the below if empty entries should be removed
    //var splitOptions = StringSplitOptions.None;
    var line = "\"125\"|\"Bio Methyl\"|\"99991\"|\"OPT12\"|\"CB\"|\"1\"|\"12\"|\"5\"|\"23\"";
    var result = line
        .Split(new[] { "|" }, splitOptions)
        .Select(p => p.Trim('\"'))
        .ToList();
    Console.WriteLine(string.Join(", ", result));
