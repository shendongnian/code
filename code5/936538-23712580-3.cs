    // Replace Field, Symbol and SomeType with actual types you use for fields, symbols and values.
    SomeType? GetCachedData(Tuple<Field, Symbol, DateTime> point)
    {
        //your caching code here
    }
    void CacheData(Tuple<Field, Symbol, DateTime> point, SomeType value)
    {
        //your caching code here
    }
    SomeType GetDataFromService(Tuple<Field, Symbol, DateTime> point)
    {
        //your service requesting code here
    }
    Tuple<Field, Symbol, DateTime, SomeType>[] GetData(IEnumerable<Field> fields, IEnumerable<Symbol> symbols, IEnumerable<DateTime> dates)
    {
        var result = new List<Tuple<Field, Symbol, DateTime, SomeType>>();
        foreach (var field in fields)
            foreach (var symbol in symbols)
                foreach (var date in dates)
                {
                    var point = new Tuple<Field, Symbol, DateTime>(field, symbol, date);
                    var cachedValue = GetCachedData(point);
                    if (cachedValue.HasValue)
                    {
                        result.Add(new Tuple<Field, Symbol, DateTime, SomeType>(field, symbol, date, cachedValue.Value);
                        continue;
                    }
                    var serviceValue = GetDataFromService(point);
                    CacheData(point, serviceValue);
                    result.Add(new Tuple<Field, Symbol, DateTime, SomeType>(field, symbol, date, serviceValue);
                }
        return result.ToArray();
    }
