    // Input string
    string str = "You have just received {{PowerUpName}} from {{PlayerName}}";
    // Initializing sample dictionary object
    var obj = new Dictionary<string,string>();
    // Filling it out
    obj.Add("PowerUpName", "Super Boost");
    obj.Add("PlayerName", "John");
    // Replacing the values with those in the dictionary
    string output = Regex.Replace(str, "(?<=\\{\\{)(.*?)(?=\\}\\})", match => obj[match.Groups[1].Value]);
    // Display result
    Console.WriteLine(output);
