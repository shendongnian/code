        private void SaveItem<T>(T item, ref int primaryKey) 
			where T : ISQLiteClass, new()
		{
			var dbConn = new SQLiteConnection(dbPath);
			T storedItem = dbConn.Find<T>(primaryKey);
			if (storedItem != null)
			{
				dbConn.Update(item);
			}
			else if (storedItem == null)
			{
				dbConn.Insert(item);
				primaryKey = item.PrimaryKey;
			}
		}
