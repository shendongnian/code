    var query = @"SELECT time(max(MyTime))
                  FROM YourTable";
    using (var db = new SQLiteConnection(your connection string))
    {
    	// MaxTime being a string that is bound to the textblock on the view.
    	MaxTime = db.CreateCommand(query).ExecuteScalar<string>();
    }
