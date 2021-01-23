    public class RewindStreamFormatterDecorator : MediaTypeFormatter
    {
        private readonly MediaTypeFormatter formatter;
        public RewindStreamFormatterDecorator(MediaTypeFormatter formatter)
        {
            this.formatter = formatter;
            this.SupportedMediaTypes.Clear();
            foreach(var type in formatter.SupportedMediaTypes)
                this.SupportedMediaTypes.Add(type);
            this.SupportedEncodings.Clear();
            foreach(var encoding in formatter.SupportedEncodings)
                this.SupportedEncodings.Add(encoding);
        }
        public override bool CanReadType(Type type)
        {
            return formatter.CanReadType(type);
        }
    
        public override Task<object> ReadFromStreamAsync(
            Type type,
            Stream readStream,
            HttpContent content,
            IFormatterLogger formatterLogger,
            CancellationToken cancellationToken)
        {
            var result = formatter.ReadFromStreamAsync
               (type, readStream, content, formatterLogger, cancellationToken);
            readStream.Seek(0, SeekOrigin.Begin);
            return result;
        }
        //There are more overridable methods but none seem to be used by ReadAsAsync
    }
