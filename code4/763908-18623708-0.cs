    public static bool Match(FirstIterationCapacitors first
        , FirstIterationCapacitors second)
    {
        return new[]{
            first.CapacitorALocation,
            first.CapacitorBLocation,
            first.CapacitorCLocation
            }.Intersect(new[]{
                second.CapacitorALocation,
                second.CapacitorBLocation,
                second.CapacitorCLocation,
            })
            .Any();
    }
