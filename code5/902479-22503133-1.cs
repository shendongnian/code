        public Task<string> TestPost()
        {
    	    var tcs = new TaskCompletionSource<string>();
          // Subscribe to event
          api.OnSomeAPIFunctionResponse += ( (s, e) => tcs.SetResult(args.value));
    
          CallAPIFunction(...with some parameters....);
          return tcs.Task;
        }
