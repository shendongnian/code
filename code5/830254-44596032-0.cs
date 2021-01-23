    public IEnumerable<string> EnumPrograms() {
        return dev.AudioSessionManager2.Sessions.AsEnumerable()
		    .Where(s => s.GetProcessID != 0)
    		.Aggregate(new List<string>(), (acc, s) => {
	    		try {
		    		var proc = Process.GetProcessById((int)s.GetProcessID).ProcessName;
			    	acc.Add(proc);
    			} catch (ArgumentException) { }
    			return acc;
    	});
    }
