    public static double ConvertUnits(this double original, SimplifiedUnits sourceUnits, SimplifiedUnits targetUnits)
    {
        if (sourceUnits == targetUnits || sourceUnits == SimplifiedUnits.Unknown)
        return original;
        if (sourceUnits == SimplifiedUnits.Feet && targetUnits == SimplifiedUnits.Meters)
        return original * GeometryConstants.MetersPerFoot;
        if (sourceUnits == SimplifiedUnits.Meters && targetUnits == SimplifiedUnits.Feet)
        return original / GeometryConstants.MetersPerFoot;
            throw new NotSupportedException();
    }
