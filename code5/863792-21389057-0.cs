    public class SectionMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public SectionMediaTypeFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
        }
