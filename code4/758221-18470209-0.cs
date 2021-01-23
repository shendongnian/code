    interface IEmailAPI{
        void SendMessage(string from, string to, string subject, string body);
    }
    class RealEmailAPI : IEmailAPI
    {
        System.Net.Mail.SmtpClient client;
        public RealEmailAPI(string host, int port)
        {
            client = new System.Net.Mail.SmtpClient(host, port);
        }
        public void SendMessage(string from, string to, string subject, string body)
        {
            client.Send(from, to, subject, body);
        }
    }
    class MockEmailAPI : IEmailAPI
    {
        public string LastAccessCode{get;private set;}
        public void SendMessage(string from, string to, string subject, string body)
        {
            var findCode = new System.Text.RegularExpressions.Regex(""); // whatever this takes
            LastAccessCode = findCode.Match(body).Value;
        }
    }
    class MyServer
    {
        IEmailAPI emailer;
        public MyServer(IEmailAPI emailSystem)
        {
            this.emailer = emailSystem;
        }
        public void SendAccessCode(string to, string code)
        {
            this.emailer.SendMessage("whatever@what.ever", to, "Access Code", code);
        }
    }
    class TestMyServer
    {
        public void TestAPICodeGen()
        {
            var email = new MockEmailAPI();
            var server = new MyServer(email);
            var code = "XYZZY";
            server.SendAccessCode("not.important@discard.com", code);
            Assert.AreEqual(code, email.LastAccessCode);
        }
    }
