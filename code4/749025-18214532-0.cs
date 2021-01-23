    private static void Test()
    {
        System.Diagnostics.Debug.WriteLine(IsNull(new int?())); // Displays True
    }
    private static bool IsNull(object obj)
    {
        return obj == null;
    }
