        public static int Main(string[] args)
        {
            Task<string> getStringTask = GetStringAsync();
            string result = getStringTask.Result; //the main thread is blocked waiting.
        
            Console.WriteLine(result);
        }
    
        public Task<string> GetStringAsync()
        {  
            // Issue the HTTP request and let the thread return from GetHttp 
            HttpResponseMessage msg = await new HttpClient().GetAsync("http://Wintellect.com/"); 
            // We never get here: The main thread is waiting for this method to finish but this method 
            // can't finish because the main thread is waiting for it to finish --> DEADLOCK! 
            return await msg.Content.ReadAsStringAsync();
        }
