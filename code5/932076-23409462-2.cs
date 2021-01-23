    private List<Task> GetFilteredTasksWithOptionalIncludes(EntityRepository<Task> repo, ITaskRequest model, TaskIncludesModel includes, string accountID)
    {
        var includedEntities = new List<Expression<Func<Task, object>>>();
        includedEntities.Add(t => t.Document.Transaction.Account);
        includedEntities.Add(p => p.Signature);
        if (includes != null)
        {
            if (includes.IncludeWorkflowActions)
            {
                includedEntities.Add(p => p.Actions);
            }
            if (includes.IncludeFileAttachments)
            {
                includedEntities.Add(p => p.Attachments);
            }
        }
        IQueryable<Task> tasks = repo.Including(includedEntities.ToArray());  
        tasks.Load();
        return tasks.ToList();  
    }
