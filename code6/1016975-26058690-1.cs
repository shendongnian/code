    internal class EmailThread
    {
        //Ensure that only one instance of EmailThread can exist
        private static readonly EmailThread Instance = new EmailThread();
        public static EmailThread Instace { get { return Instance; } }
        //Here is our Queue
        public ConcurrentQueue<MailMessage> Messages { get; private set; }
        private EmailThread()
        {
            Messages = new ConcurrentQueue<MailMessage>();
        }
        // This method is called when the thread is started and repeated once a 10 seconds
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("email sender thread: working...");
                if (!Messages.IsEmpty)
                {
                    //define SMTP credentials here
                    var smtp = new SmtpClient()
                    var failed = new Queue<MailMessage>();
                    MailMessage message;
                    while (Messages.TryDequeue(out message))
                    {
                        try
                        {
                            smtp.Send(message);
                            Console.WriteLine("email sender thread: successfully sent email...");
                        }
                        catch (SmtpException)
                        {
                            //Enqueue again if failed
                            failed.Enqueue(message);
                            Console.WriteLine("email sender thread: error sending email, enqueuing...");
                        }
                    }
                    foreach (var mailMessage in failed)
                    {
                        Messages.Enqueue(mailMessage);
                    }
                    smtp.Dispose();
                }
                Thread.Sleep(10000);
            }
            Console.WriteLine("email sender thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;
    }
