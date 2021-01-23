    public string artistsList {
        get {
            return String.Join(", ", artists.Select(a => a.name).ToArray());        
        }
    }
