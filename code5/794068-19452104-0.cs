    public static List<T> getMatches<T>(List<T> list, string search) {
        return list.Select(x => new {
                            X = x, 
                            Props = x.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public),
                            Fields = x.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public),
            })
            .Where(x => x.Props.Any(p => 
                                {var val = p.GetValue(x.X, null); 
                                    return val != null && val.ToString().Contains(search);})
                        || x.Fields.Any(p => 
                                {var val = p.GetValue(x.X); 
                                    return val != null && val.ToString().Contains(search);}))
            .Select(x => x.X)
            .ToList();
    }
