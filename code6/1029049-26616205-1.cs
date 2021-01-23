	public int SaveItem (TodoItem item)
	{
		lock (locker) {
			if (item.ID != 0) {
				database.Update(item);
				return item.ID;
			} else {
				return database.Insert(item);
			}
		}
	}
