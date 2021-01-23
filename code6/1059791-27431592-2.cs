    public Component(string name, params KeyValuePair<string, object>[] parameters)
    {
        Name = name;
        Parameters = new Dictionary<string, object>(parameters);
    }
