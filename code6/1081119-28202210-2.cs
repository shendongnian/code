		// called within a database connection's using statement
		protected override void Query(DatabaseContext db)
		{
			// check the database for the user account
			if(_account == null && !String.IsNullOrEmpty(_userID))
			{
				int tempID;
				int? id;
				id = int.TryParse(_userID, out tempID) ? tempID : (int?)null;
				if(id.HasValue)
				{
					_sessionRestored = true;
					_account = db.User.Find(id);
					if(_account != null)
					{
						_account.LastLogon = DateTime.UtcNow;
						db.SaveChanges();
					}
				}
			}
		}
