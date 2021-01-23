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
                for (int i = 0; i < dbEntry.Employees.Count; i++)/*Please note that if lazy loading is not True then this reference must explicitly be loaded*/
			    {
			       dbEntry.Employees.Remove(dbEntry.Employees.First());
			    }
                foreach (var item in memo.Employees)
	            {
		            dbEntry.Employees.Add(item);
	            }                
            }
        }
        context.SaveChanges(); //error 2 here
    }
