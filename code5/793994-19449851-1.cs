    public static IEnumerable<FileInfo> GetWithMaxAggregatedSize(this IEnumerable<FileInfo> files, long maxTotalSize)
    {
        long aggregatedSize = 0;
        return files.Where(fileInfo => 
        {
            aggregatedSize += fileInfo.Length;
            return aggregatedSize <= maxTotalSize;
        });
    }
