    Dictionary<Keys, string> keys = new Dictionary<Keys, string>();
    foreach (Keys key in Enum.GetValues(typeof(Keys)))
    {
        if (!keys.ContainsKey(key))
        {
            keys.Add(key, key.ToString());
        }
    }
