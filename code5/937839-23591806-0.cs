    public IEnumerable<string> getGenres()
    {
        var genres = (from item in data.Descendants("genre")
                     select item.Value).Distinct();
        return genres.ToArray();
    }
