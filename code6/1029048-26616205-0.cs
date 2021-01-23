	public TodoItemDatabase()
	{
		database = DependencyService.Get<ISQLite> ().GetConnection ();
		// create the tables
		database.CreateTable<TodoItem>();
	}
