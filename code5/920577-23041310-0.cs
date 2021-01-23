    public class ImageInfo
    {
        public ImageInfo(byte[] bytes, string description)
        {
            this.Bytes = bytes;
            this.Description = description;
        }
        public byte[] Bytes {get;set;}
        public string Description {get;set;}
    }
