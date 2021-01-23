    public bool ScheduleTask(string taskname, DateTime startTime, DateTime endTime)
    {
    	__ContractsRuntime.Requires(!string.IsNullOrWhiteSpace(taskname), null, "!string.IsNullOrWhiteSpace(taskname)");
    	__ContractsRuntime.Requires(true, null, "startTime != null");
    	__ContractsRuntime.Requires(true, null, "endTime != null");
    	return true;
    }
