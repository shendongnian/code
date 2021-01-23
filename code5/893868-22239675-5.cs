    public class with_fake_gravatar_web_service
        {
        Establish context = () =>
            {
            MessageHandler = new LoggingHttpMessageHandler(new HttpResponseMessage(HttpStatusCode.OK));
            GravatarClient = new HttpClient(MessageHandler);
            Filesystem = A.Fake<FakeFileSystemWrapper>();
            Fetcher = new GravatarFetcher(Committers, GravatarClient, Filesystem);
            };
        protected static LoggingHttpMessageHandler MessageHandler;
        protected static HttpClient GravatarClient;
        protected static FakeFileSystemWrapper Filesystem;
        }
