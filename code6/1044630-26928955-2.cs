    private Dictionary<string,int> dictionary;
    //... (Remember to initialize the dictionary!)
    private void AddVisits(string directory, int visits) {
        string[] segments = Regex.Split("(\\|\/)+", directory);
        string topLevelDir = (directory.StartsWith("/") || directory.StartsWith("\\")) ?
                              segments[1] :
                              segments[0];
        topLevelDir = "/" + topLevelDir;
        int newVisits = visits;
        if(dictionary.ContainsKey(topLevelDir))
           newVisits += dictionary[topLevelDir];
        dictionary[topLevelDir] = newVisits;
    }
