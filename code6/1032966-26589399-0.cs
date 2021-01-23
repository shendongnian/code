    /// <summary>
    /// Get the latest unprocessed batch service command per queue
    /// </summary>
    /// <returns></returns>
    public IQueryable<ReportQueueServiceCommandDTO> GetLatestUnprocessedCommandFromQueue()
    {
    
    	// Get the maximum Acknowledged record per queue
    	var maxDateTimePerAcknowledgedQueue = this.Get()
    		.Where(w => w.IsCommandAcknowledged)
    		.GroupBy(gb => gb.QueueNumber)
    		.Select(s => new ReportQueueServiceCommandDTO()
    		{
    			Id = (int)s.Max(m => m.Id),
    			CommandDatetime = s.FirstOrDefault(fod => fod.Id == s.Max(max => max.Id)).CommandDatetime,
    			CommandId = s.FirstOrDefault(fod => fod.Id == s.Max(max => max.Id)).CommandId,
    			IsCommandAcknowledged = true,
    			QueueNumber = s.Key
    		});
    
    	// Get the maximum unacknowledged record per queue
    	var maxDateTimePerUnacknowledgedQueue = this.Get()
    		.Where(w => !w.IsCommandAcknowledged)
    		.GroupBy(gb => gb.QueueNumber)
    		.Select(s => new ReportQueueServiceCommandDTO()
    		{
    			Id = (int)s.Max(m => m.Id),
    			CommandDatetime = s.FirstOrDefault(fod => fod.Id == s.Max(max => max.Id)).CommandDatetime,
    			CommandId = s.FirstOrDefault(fod => fod.Id == s.Max(max => max.Id)).CommandId,
    			IsCommandAcknowledged = false,
    			QueueNumber = s.Key
    		});
    
    	// Get the maximum unacknowledged record which had an ID greater than the maximum acknowledged record per queue.
    	// If the queue entry does not yet exist from MaxDateTimesPerAcknowledgedQueue, use the record anyway (left join-ish)
    	return (from unack in maxDateTimePerUnacknowledgedQueue
    		   join ack in maxDateTimePerAcknowledgedQueue on unack.QueueNumber equals ack.QueueNumber into joinedRecords
    		   from subAck in joinedRecords.Where(w => w.Id > unack.Id).DefaultIfEmpty()
    		   select new ReportQueueServiceCommandDTO()
    		   {
    			   Id = (subAck.Id == null ? unack.Id : subAck.Id),
    			   CommandDatetime = (subAck.CommandDatetime == null ? unack.CommandDatetime : subAck.CommandDatetime),
    			   CommandId = (subAck.CommandId == null ? unack.CommandId : subAck.CommandId),
    			   IsCommandAcknowledged = (subAck.IsCommandAcknowledged == null ? unack.IsCommandAcknowledged : subAck.IsCommandAcknowledged),
    			   QueueNumber = (subAck.QueueNumber == null ? unack.QueueNumber : subAck.QueueNumber)
    		   })
    		   .Where(w => !w.IsCommandAcknowledged);
    }
