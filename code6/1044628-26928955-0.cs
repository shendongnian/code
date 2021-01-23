    private void AddVisits(string directory, int visits) {
        string[] segments = Regex.Split("(\\|\/)+", directory);
        string firstSegment = String.Empty;
        
        if(directory.StartsWith("/") || directory.StartsWith("\\"))
             firstSegment = segments[1];
        else
             firstSegment = segments[0];
        if(!dictionary.ContainsKey(firstSegment))
            dictionary.Add(firstSegment, visits);
        else {
            int lastVisits = dictionary[firstSegment]
            dictionary[firstSegment] = lastVisits + visits;
        }
    }
