    if (salePredicate != null)
    {
        if (!salePredicate.Invoke(s))
        {
            continue;
        }
        else
        {
            _sales.Add(s);
        }
    }
