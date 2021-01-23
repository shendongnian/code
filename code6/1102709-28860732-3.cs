    // /api/Agency
    public List<AgencyData> Get()
    {
        var json = SQLAllAgencyData("");
        return json;
    }
    
    // /api/Agency?state=texas&city=dallas
    public List<AgencyData> Get(string state, string city)
    {
        // Params will be equal to your values...
        var json = SQLAllAgencyData("");
        return json;
    }
