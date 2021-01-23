    public ActionResult Index()
        {
            List<Tweet> model = null;
            var client = new HttpClient();
            var task = client.GetAsync("http://localhost:33615/api/product").ContinueWith((t) =>
            {
                var response = t.Result;
                var readtask = response.Content.ReadAsAsync<List<Tweet>>();
                readtask.Wait();
                model = readtask.Result;
            });
            task.Wait();
            return View(model);
        }
