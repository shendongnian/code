    // Wrap in an outer class, then you can still register AppHost with `typeof(MyService).Assembly`
    public partial class MyService
    {
        public class MyPublicService : Service
        {
            public object Get(GetPublicData request)
            {
                return {};
            }
        }
        [MyBasicAuth] // <- Check is now class level, can run as expected before Validation
        public class MySecureService : Service
        {
            public object Get(GetSecureData request)
            {
                return {};
            }
        }
    }
