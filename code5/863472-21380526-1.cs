    // Your code here
    var data = new List<Triplet>();
    
    // Add rows
    data.Add(new Triplet("John", "Paul", "George"));
    data.Add(new Triplet("Gene", "Paul", "Ace"));
    
    // Display
    foreach(Triplet row in data)
    {
        Console.WriteLine("{0}, {1}, {2}", row.Item1, row.Item2, row.Item3);
    }
