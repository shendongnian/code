    public async Task<ActionResult> Index()
        {
            Log("before GetAsync");
            await new HttpClient().GetAsync("http://www.example.com/")
            Log("ContinueWith");
            request.Result.EnsureSuccessStatusCode();
        
            return View();
        }
