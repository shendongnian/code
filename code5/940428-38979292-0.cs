    public string GetRandomHexColor()
    {
        var result = "#" + Guid.NewGuid().ToString().Substring(0, 6);
        return result;
    }
