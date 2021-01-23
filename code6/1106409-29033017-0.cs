    public async List<Person> Search()
	{
		// you'd access your xml here
		TextView nameTextView = null;
		// using real keys
		MobileServiceClient client = new MobileServiceClient(AppUrl, AppKey);
		// and real data objects
		IMobileServiceTable<Person> personTable = client.GetTable<Person> ();
		// just to keep things clean, an interstitial var
		string name = nameTextView.Text;
		// use LINQ to filter on the properties we care about
		// you can add && p.Blah == whatever, as much as you'd like
		return await personTable.Where (p => p.Name == name).ToListAsync();
	}
