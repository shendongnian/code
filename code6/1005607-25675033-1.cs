    public bool IsNullOrEmpty(object enumerable)
    {
        if (enumerable != null)
        {
            if (enumerable is IEnumerable)
            {
                using(var enumerator = ((IEnumerable)enumerable).GetEnumerator())
                    return enumerator.MoveNext();
            }
        }
        return false;
    }
