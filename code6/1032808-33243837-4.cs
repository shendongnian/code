    public class FileChunkMetaData
    {
        public string ChunkIdentifier { get; set; }
    
        public long? ChunkStart { get; set; }
    
        public long? ChunkEnd { get; set; }
    
        public long? TotalLength { get; set; }
    
        public bool IsLastChunk
        {
            get { return ChunkEnd + 1 >= TotalLength; }
        }
    }
    public class UploadProcessingResult
    {
        public bool IsComplete { get; set; }
    
        public string FileName { get; set; }
    
        public string LocalFilePath { get; set; }
    
        public NameValueCollection FileMetadata { get; set; }
    }
