    class Program
        {
            static void Main()
            {
            List<IEmailConfiguration> performedCalls = new List<IEmailConfiguration>();
            // preparing test instance
            var mailerMock = MockRepository.GenerateStrictMock<Mailer>();
            mailerMock.Expect(x => x.SendMessage(Arg<DummyEmailConfiguration>.Is.Anything))
                      .WhenCalled(methodInvocation =>
                      {
                          var config = methodInvocation.Arguments.OfType<IEmailConfiguration>().Single();
                          performedCalls.Add(config);
                      });
            // testing 
            for (int i = 0; i < 10; i++)
            {
                mailerMock.SendMessage(new DummyEmailConfiguration("world" + i + "@mail.com", "hello world" + i));
            }
            // dumping info
            foreach (var call in performedCalls)
            {
                Console.WriteLine(call);
            }
        }
    }
    public interface IEmailConfiguration
    {
        string To { get; }
        string Message { get; }
    }
    public interface Mailer
    {
        void SendMessage(IEmailConfiguration config);
    }
    internal class DummyEmailConfiguration : IEmailConfiguration
    {
        public DummyEmailConfiguration(string to, string message)
        {
            To = to;
            Message = message;
        }
        public string To
        {
            get;
            private set;
        }
        public string Message
        {
            get;
            private set;
        }
        public override string ToString()
        {
            return To + ": " + Message;
        }
    }
