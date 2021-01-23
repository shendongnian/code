    public static IEnumerable<FileInfo> GetWithMaxAggregatedSize(this IEnumerable<FileInfo> files, long maxTotalSize)
    {
        long aggregatedSize = 0;
        return files.TakeWhile(fileInfo => 
        {
            aggregatedSize += fileInfo.Length;
            return aggregatedSize <= maxTotalSize;
        });
    }
