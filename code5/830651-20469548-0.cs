    public static class StorageItemExtensions
    {
        public static async Task<IDictionary<string, object>> GetSpace(this IStorageItem sf)
        {
            var properties = await sf.GetBasicPropertiesAsync();
            return await properties.RetrievePropertiesAsync(new[] { "System.FreeSpace", "System.Capacity" });
        }
    
        public static string GetSizeString(this ulong sizeInB, double promoteLimit = 1024, double decimalLimit = 10, string separator = " ")
        {
            if (sizeInB < promoteLimit)
                return string.Format("{0}{1}B", sizeInB, separator);
    
            var sizeInKB = sizeInB / 1024.0;
    
            if (sizeInKB < decimalLimit)
                return string.Format("{0:F2}{1}KB", sizeInKB, separator);
    
            if (sizeInKB < promoteLimit)
                return string.Format("{0:F2}{1}KB", sizeInKB, separator);
    
            var sizeInMB = sizeInKB / 1024.0;
    
            if (sizeInMB < decimalLimit)
                return string.Format("{0:F2}{1}MB", sizeInMB, separator);
    
            if (sizeInMB < promoteLimit)
                return string.Format("{0:F2}{1}MB", sizeInMB, separator);
    
            var sizeInGB = sizeInMB / 1024.0;
    
            if (sizeInGB < decimalLimit)
                return string.Format("{0:F2}{1}GB", sizeInGB, separator);
    
            if (sizeInGB < promoteLimit)
                return string.Format("{0:F2}{1}GB", sizeInGB, separator);
    
            var sizeInTB = sizeInGB / 1024.0;
    
            if (sizeInTB < decimalLimit)
                return string.Format("{0:F2}{1}TB", sizeInTB, separator);
    
            return string.Format("{0:F2}{1}TB", sizeInTB, separator);
        }
    }
