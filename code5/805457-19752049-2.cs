    static public IEnumerable<double> ConvertToDouble(this IEnumerable<string> source)
    {
        double x = 0;
        var result = source.Where(str => Double.TryParse(str, out x))
                            .Select (str => x);
    
        return result;      
    }
