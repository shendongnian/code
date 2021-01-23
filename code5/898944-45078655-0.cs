    public static class MemoryCacheHackExtensions
    {
        public static long GetApproximateSize(this MemoryCache cache)
        {
            var statsField = typeof(MemoryCache).GetField("_stats", BindingFlags.NonPublic | BindingFlags.Instance);
            var statsValue = statsField.GetValue(cache);
            var monitorField = statsValue.GetType().GetField("_cacheMemoryMonitor", BindingFlags.NonPublic | BindingFlags.Instance);
            var monitorValue = monitorField.GetValue(statsValue);
            var sizeField = monitorValue.GetType().GetField("_sizedRefMultiple", BindingFlags.NonPublic | BindingFlags.Instance);
            var sizeValue = sizeField.GetValue(monitorValue);
            var approxProp = sizeValue.GetType().GetProperty("ApproximateSize", BindingFlags.NonPublic | BindingFlags.Instance);
            return (long)approxProp.GetValue(sizeValue, null);
        }
    }
