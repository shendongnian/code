    void UpdateCount(string key)
    {
        Foo f;
        if (dict.TryGetValue(key, out f))
        {
            // do the update
            ++f.Count;
        }
        else
        {
            dict[key] = 1;
        }
    }
