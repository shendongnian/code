    private static string GetDestination(Role x)
    {
        Type type = x == null ? null : x.GetType();
        while (type != null)
        {
            string destination;
            if (DestinationsByType.TryGetValue(x.GetType(), out destination))
            {
                return destination;
            }
            type = type.BaseType;
        }
        return @"\Home";
    }
