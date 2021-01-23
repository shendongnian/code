    public void ListFruit()
    {
      using (var db = new SQLite.SQLiteConnection(this.DBPath))
      {
          List<Fruits> retrievedTasks = db.Table<Fruits>().ToList<Fruits>();
          myListbox.ItemsSource = retrievedTasks; // or directly
      }
    } 
