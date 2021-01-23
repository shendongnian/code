    private readonly BlockingCollection<EmailData> _Emails =
        new BlockingCollection<EmailData>(new ConcurrentQueue<EmailData>());
    
    // producer can add data here
    public void Add(EmailData emailData)
    {
        _Emails.Add(emailData);
    }
    
    public void Run()
    {
        // create a consumer thread
        Task.Run(() => 
        {
            foreach (var emailData in _Emails.GetConsumingEnumerable())
            {
                SendEmail(emailData);
            }
        });
    }
    
    // sending email implementation
    private void SendEmail(EmailData emailData)
    {
        throw new NotImplementedException();
    }
