    Task.Run(() => {
    	var audit = new Audit
            {
                Id = Guid.NewGuid(),
                IPAddress = request.UserHostAddress,
                UserId = id,
                Resource = request.RawUrl,
                Timestamp = DateTime.UtcNow
            };
    
        var database = (new NinjectBinder()).Kernel.Get<IDatabaseWorker>();
        database.Audits.InsertOrUpdate(audit);
        database.Save();
            
    }).ContinueWith(task => {
    	task.Exception.Handle(ex => {
    		var username = WebSecurity.CurrentUserName;
            Debugging.DispatchExceptionEmail(ex, username);
    	});
    	
    }, TaskContinuationOptions.OnlyOnFaulted);
