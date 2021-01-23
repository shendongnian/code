    //Your own Custom Result, writes directly to response stream
    public class ImageResult : IDisposable, IStreamWriter, IHasOptions
    {
        private readonly Image image;
        private readonly ImageFormat imgFormat;
        public ImageResult(Image image, ImageFormat imgFormat = null)
        {
            this.image = image;
            this.imgFormat = imgFormat ?? ImageFormat.Png;
            this.Options = new Dictionary<string, string> {
                { HttpHeaders.ContentType, this.imgFormat.ToImageMimeType() }
            };
        }
        public void WriteTo(Stream responseStream)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, imgFormat);
                ms.WriteTo(responseStream);
            } 
        }
        public void Dispose()
        {
            this.image.Dispose();
        }
        public IDictionary<string, string> Options { get; set; }
    }
