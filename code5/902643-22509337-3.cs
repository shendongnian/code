    using(var enumerator = reader.GetEnumerator())
    {
        // Move to first
        if(!enumerator.MoveNext())
            throw new NotImplementedException();
        var value = enumerator.Current[0].ToString();
    }
