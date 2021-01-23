    var json = "bla bla bla json";
    var dictionaries = new JavaScriptSerializer()
        .Deserialize<Dictionary<string, string>[]>(json);
    foreach (var dictionary in dictionaries)
    {
        foreach (var pair in dictionary)
        {
            Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
        }
    }
    Console.WriteLine(dictionaries[0]["0"]); // 21838
