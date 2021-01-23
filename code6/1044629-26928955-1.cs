    private void AddVisits(string directory, int visits) {
        string[] segments = Regex.Split("(\\|\/)+", directory);
        string firstSegment = (directory.StartsWith("/") || directory.StartsWith("\\")) ?
                              segments[1] :
                              segments[0];
        firstSegment = "/" + firstSegment;
        int newVisits = visits;
        if(dictionary.ContainsKey(firstSegment))
           newVisits += dictionary[firstSegment];
        dictionary[firstSegment] = newVisits;
    }
