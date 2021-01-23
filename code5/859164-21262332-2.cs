    public class MyService : Service
    {
        // Unauthenticated API method
        public object Get(GetPublicData request)
        {
            return {};
        }
        // Secure API method
        [MyBasicAuth] // <- Checks user has permission to run this method
        public object Get(GetSecureData request)
        {
            return {};
        }
    }
