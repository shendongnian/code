    async Task<IEnumerable<PingReply>> GetPingReplies(IEnumerable<string> hosts)
    {
    
    	
    	var tasks=hosts.Select(host=>{
    		var ping=new Ping();
    		var task=ping.SendPingAsync(host);
    		return task;
    	}).ToArray();
    	await Task.WhenAll(tasks);
    	return tasks.Select(task=>task.Result);
    	
    }
