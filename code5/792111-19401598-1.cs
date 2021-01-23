    public IList<string> FormatAddress(IList<string> addressParts)
    {
        var result = addressParts.Where(a => !string.IsNullOrEmpty(a)).ToList();
        result = result.Concat(Enumerable.Repeat((string)null, addressParts.Count - result.Count)).ToList();
        return result;
    }
