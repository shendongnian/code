    public static class EqualsAnyExtension
    {
        public static bool EqualsAny<T>(this T value, params T[] items)
        {
            return items.Contains(value);
        }
    }
