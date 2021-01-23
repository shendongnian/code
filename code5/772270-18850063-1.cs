    public Boolean CompleteTask<TEntity>()
    {
    	TEntity myCurrentRecord = db.Task.OfType<TEntity>().Single(r => r.Id == myId);
    	myCurrentRecord.IsComplete = true;
    	if (db.SaveChanges() > 0)
    		return true;
    	else return false;
    }
