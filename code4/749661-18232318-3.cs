    private static long ConvertLargeIntegerToLong(object largeInteger)
    {
        Type type = largeInteger.GetType();
 
        int highPart = (int)type.InvokeMember("HighPart", BindingFlags.GetProperty, null, largeInteger, null);
        int lowPart = (int)type.InvokeMember("LowPart", BindingFlags.GetProperty | BindingFlags.Public, null, largeInteger, null);
 
        return (long)highPart <<32 | (uint)lowPart;
    }
    object accountExpires = DirectoryEntryHelper.GetAdObjectProperty(directoryEntry, "accountExpires");
    var asLong = ConvertLargeIntegerToLong(accountExpires);
 
    if (asLong == long.MaxValue || asLong <= 0 || DateTime.MaxValue.ToFileTime() <= asLong)
    {
        return DateTime.MaxValue;
    }
    else
    {
        return DateTime.FromFileTimeUtc(asLong);
    }
