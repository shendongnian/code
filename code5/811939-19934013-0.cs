    public string mood()
    {
        var unhappiness = Hunger + Boredom;
        string m = string.Empty;
        if (unhappiness < 5)
        {
            m = "Happy";
        }
            // etc
        return m;
    }
