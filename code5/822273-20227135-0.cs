    public class RestServiceRequest : IRequiresRequestStream
    {
        public Stream stream;
        Stream IRequiresRequestStream.RequestStream
        {
            get
            {
                return stream;
            }
            set
            {
                stream = value;
            }
        }
    }
