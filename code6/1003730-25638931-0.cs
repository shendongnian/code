    SQLiteAsyncConnection conn = new SQLiteAsyncConnection("people");var query = conn.Table<Person>().Where(x => x.Name == "Matteo");
    var result = await query.ToListAsync();
    foreach (var item in result)
    {
        Debug.WriteLine(string.Format("{0}: {1} {2}", item.Id, item.Name, item.Surname));
    }
