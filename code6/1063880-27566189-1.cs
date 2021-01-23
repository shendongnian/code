    public void SaveMemo(EFDbContext dbContext, Memo memo) 
    {
        if(memo.MemoId == Guid.Empty) 
        {
            memo.MemoId = Guid.NewGuid();
            context.Memos.Add(memo); //error 1 here 
        } else 
        {
            Memo dbEntry = dbContext.Memos.Find(memo.MemoId);
            if(dbEntry != null) 
            {
                dbEntry.Message = memo.Message;
                foreach (var item in memo.Employees)
	            {
		            dbEntry.Employees.Add(item);
	            }                
            }
        }
        dbContext.SaveChanges(); //error 2 here
    }
