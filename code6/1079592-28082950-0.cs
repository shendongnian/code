    public IList<YogaSpace> FirstWithinDistance(DbGeography myLocation, double N)
    {
        var spaces = context.YogaSpaces();
        return spaces .Where(y => CalculateDistance(yogaSpace.Location, myLocation) <= N).ToList();
    }
