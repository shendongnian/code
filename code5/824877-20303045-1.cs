    private ICookieProvider cookieProvider;
    public MyController(ICookieProvider cookieProvider)
    {
        this.cookieProvider = cookieProvider;
    }
    public MyController() : this(new RealCookieProvider()) { }
