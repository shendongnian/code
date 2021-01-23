		public async void Data()
		{
			var curUser = ParseUser.CurrentUser.Username.ToString ();
			Console.WriteLine ("User: " + curUser);
			var query = ParseObject.GetQuery("UserData")
				.WhereEqualTo("username", curUser);
			IEnumerable<ParseObject> results = await query.FindAsync();
			ParseObject userData = await query.FirstAsync ();
		}
