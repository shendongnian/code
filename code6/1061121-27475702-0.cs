    public void InitiateBulkDischargeWorkflow(
		string workflowDefinitionName,
		IDictionary<string, object> args)
    {
		var tasks =
			from memberId in args["argMemberIds"] as List<int>
			let memberArgs = new Dictionary<string, object>()
			{
				{ "argMemberId", memberId },
				{ "argInitiatorId", CurrentUserId },
			}
			select Task.Run(() =>
				memberManager.InitiateWorkflow(
					initiatorId,
					memberId,
					workflowDefinitionName,
					memberArgs));
		
		Task.WhenAll(tasks);
    }
