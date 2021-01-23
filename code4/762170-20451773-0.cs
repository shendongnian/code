	var dictionary = new TransactionalDictionary<int, string>();
	dictionary.Add(1, "A");
			
	// #1: committed transaction
	using (var scope = new TransactionScope())
	{
		dictionary.Add(2, "B");
		dictionary.Add(3, "C");
		dictionary.Add(4, "D");
		scope.Complete();
	}
	Debug.Assert(dictionary[3] == "C");
	// #2: uncommitted transaction
	using (var scope = new TransactionScope())
	{
	  dictionary[1] = "Z";
	  
	  // transaction is not completed -> rollback to initial state 
	  //scope.Complete();
	}
	Debug.Assert(dictionary[1] == "A");
