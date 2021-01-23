    private static void ExploreResult(object result)
    {
     if (result != null &&
         !(result.GetType().IsValueType) &&
         !((IEnumerable)result).GetType().GetProperty("Item").PropertyType.IsValueType)
        )
        Console.WriteLine("explore");
    }
