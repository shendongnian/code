    ParseQuery<ParseObject> query = ParseObject.GetQuery("Horse");
    IEnumerable<ParseObject> horses = await query.FindAsync();
    foreach (ParseObject horse in horses)
    {
    	string name = horse.Get<string>("Name");
    	Debug.WriteLine("Horse: " + name);
    }
