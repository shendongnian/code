    public void SaveMemo(Memo memo) 
    {
        if(memo.MemoId == Guid.Empty) 
        {
            memo.MemoId = Guid.NewGuid();
            context.Memos.Add(memo); //error 1 here 
        } else 
        {
            Memo dbEntry = context.Memos.Find(memo.MemoId);
            if(dbEntry != null) 
            {
                dbEntry.Message = memo.Message;
                foreach (var item in memo.Employees)
	            {
		            dbEntry.Employees.Add(item);
	            }                
            }
        }
        context.SaveChanges(); //error 2 here
    }
