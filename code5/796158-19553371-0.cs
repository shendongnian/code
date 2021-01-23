    using System;
    using System.Threading.Tasks;
    using Windows.Storage;
    namespace WinRTXamlToolkit.IO.Extensions
    {
        public static class StorageItemExtensions
        {
            public static async Task<UInt64> GetFreeSpace(this IStorageItem sf)
            {
                var properties = await sf.GetBasicPropertiesAsync();
                var filteredProperties = await properties.RetrievePropertiesAsync(new[] { "System.FreeSpace" });
                var freeSpace = filteredProperties["System.FreeSpace"];
                return (UInt64)freeSpace;
            }
            public static string GetSizeString(this ulong sizeInB, double promoteLimit = 1024, double decimalLimit = 10, string separator = " ")
            {
                if (sizeInB < promoteLimit)
                    return string.Format("{0}{1}B", sizeInB, separator);
                var sizeInKB = sizeInB / 1024.0;
                if (sizeInKB < decimalLimit)
                    return string.Format("{0:F1}{1}KB", sizeInKB, separator);
                if (sizeInKB < promoteLimit)
                    return string.Format("{0:F0}{1}KB", sizeInKB, separator);
                var sizeInMB = sizeInKB / 1024.0;
                if (sizeInMB < decimalLimit)
                    return string.Format("{0:F1}{1}MB", sizeInMB, separator);
                if (sizeInMB < promoteLimit)
                    return string.Format("{0:F0}{1}MB", sizeInMB, separator);
                var sizeInGB = sizeInMB / 1024.0;
                if (sizeInGB < decimalLimit)
                    return string.Format("{0:F1}{1}GB", sizeInGB, separator);
                if (sizeInGB < promoteLimit)
                    return string.Format("{0:F0}{1}GB", sizeInGB, separator);
                var sizeInTB = sizeInGB / 1024.0;
                if (sizeInTB < decimalLimit)
                    return string.Format("{0:F1}{1}TB", sizeInTB, separator);
                return string.Format("{0:F0}{1}TB", sizeInTB, separator);
            }
        }
    }
