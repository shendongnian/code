    public sealed class HtmlDataObject : DataObject, IDisposable
    {
        protected MemoryStream HtmlMemoryStream { get; set; }
    
        public HtmlDataObject(MemoryStream memoryStream, string fallBackText)
        {
            HtmlMemoryStream = memoryStream;
            SetText(fallBackText);
            SetData(DataFormats.Html, false, HtmlMemoryStream );
        }
        public void Dispose()
        {
            HtmlMemoryStream .Dispose();
        }
    }
