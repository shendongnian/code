    public async Task<ActionResult> Index()
        {
            Log("before GetAsync");
            await new HttpClient().GetAsync("http://www.example.com/");
            //everything below here is you 'continuation' on the request context
            Log("ContinueWith");
            request.Result.EnsureSuccessStatusCode();
        
            return View();
        }
