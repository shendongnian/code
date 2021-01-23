    object result = HttpContext.Current.Cache.Get(key);
    if(result != null)
    {
        return ((Maybe<string>)result).Else(() => null);
    }
    var value = Maybe.From(GetValueFromDb());
    HttpContext.Current.Cache.Add(key, value, ...);
    return value;
