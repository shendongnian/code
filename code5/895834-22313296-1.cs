    public void Post()
    {
        Task.Factory.StartNew(() =>
        {
            SendEmail("a@b.com");
            SendEmail("b@c.com");
        });
    }
