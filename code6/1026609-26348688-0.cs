    private static Bar bar;
    public static Bar Bar
    {
        get
        {
            bar = bar ?? new Bar();
            return bar;
        }
    }
