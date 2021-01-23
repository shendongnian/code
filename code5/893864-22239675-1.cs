    public class with_fake_gravatar_web_service : with_fake_committer_list
        {
        Establish context = () =>
            {
            MessageHandler = new LoggingHttpMessageHandler(new HttpResponseMessage(HttpStatusCode.OK));
            GravatarClient = new HttpClient(MessageHandler);
            Filesystem = A.Fake<FakeFileSystemWrapper>();
            Fetcher = new GravatarFetcher(Committers, GravatarClient, Filesystem);
            };
        protected static GravatarFetcher Fetcher;
        protected static LoggingHttpMessageHandler MessageHandler;
        protected static HttpClient GravatarClient;
        protected static FakeFileSystemWrapper Filesystem;
        }
