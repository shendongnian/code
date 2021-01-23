      public async Task<ActionResult> Async()
       {
          var sw = Stopwatch.StartNew();
          var data = await GetVideosAsync();
          sw.Stop();
          ViewBag.Elapsed = sw.ElapsedMilliseconds;
         return View("~/views/home/index.cshtml", data);	 
       }
    	
        async Task<IEnumerable<IEnumerable<Video>>> GetVideosAsync()
        {
            var allVideosTasks = new List<Task<IEnumerable<Video>>>();
            foreach (var url in sources)
            {
               allVideosTasks.Add(DownloadDataAsync(url));
            }
            
            await Task.WhenAll(allVideosTasks.ToArray());       
    			 
            return allVideosTasks.Select(x => x.Result);
        }
