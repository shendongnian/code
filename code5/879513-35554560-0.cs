    public IEnumerable<T> GetItems<T>() where T: new()
		{
			lock (locker) {
				return dbCon.Table<T> ().ToArray ();
			}
		}
