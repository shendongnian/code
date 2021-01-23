    public static bool IsAnonymous(this MethodInfo method)
    {
         var invalidChars = new[] {'<', '>'};
         return method.Name.Any(invalidChars.Contains);
    }
