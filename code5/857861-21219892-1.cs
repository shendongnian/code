    List<Task> tasks = new List<Task>();
    foreach(Friend f in chatLib.Friends)
    {
        Task task = Task.Factory.StartNew( ( arg ) => 
        {chatLib.GetPhoto(arg); contactWindowControl.AddContactToList(arg); }, f );
        tasks.Add(task);
    }
    Task.WaitAll(tasks.ToArray());
			
			
