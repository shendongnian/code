    [Route("/upload/{FileName}")]
    public class Upload : IRequiresRequestStream
    {
        public Stream RequestStream { set; get; }
        public string FileName { set; get; }
    }
