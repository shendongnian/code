    var tempItemList = new List<MyStuff>();
    foreach(var item in listOfItemsToBeAdded)
    {
        //biz logic
        tempItemList.Add(item)
    }
    
    using (var transaction = context.Transaction())
    {
    	try
    	{
    		context.BulkInsert(tempItemList);
    		transaction.Commit();
    	}
    	catch (Exception ex)
    	{
    		// Handle exception
    		transaction.Rollback();
    	}
    }
