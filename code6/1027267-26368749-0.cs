    List<string> listofdates = new List<string>();
    foreach (var x in fi)
    {
        Console.WriteLine(x.Name.Substring(x.Name.Length - 15, 10));
        listofdates.Add(x);
    }
    var orderedList = listofdates.OrderByDescending(x => DateTime.Parse(x.Name.Substring(x.Name.Length - 15, 10))).ToList();
