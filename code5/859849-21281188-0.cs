    public class RequestFactory : IRequestFactory
    {
        public ISupportHardwareEnquiry CreateSupportHardwareEnquiry()
        {
            return new SupportHardwareEnquiry();
        }
    
    
        public IRequest CreateAlternateDriverEnquiry()
        {
            return new AlternateDriverEnquiry();
        }
    }
