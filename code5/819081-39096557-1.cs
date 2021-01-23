    public async Task<ActionResult> Index()
    {
        Email email = new Email();
        email.SendAsync();
    }
