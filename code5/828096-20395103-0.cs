    [OutputCache(Duration = 60)] // Caches for 60 seconds
    private List<string> Values()
    {
        if (ViewBag.Sample == null)
        {
            ViewBag.Sample = TestData();
        }
    }
