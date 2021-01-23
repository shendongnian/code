    public async static Task<Item> QueryTable()
    {
        var table = App.MobileService.GetTable<Item>();
        IMobileServiceTableQuery<Item> query = table.
            OrderBy(item => item.Id);
        return await query.ToListAsync();
    }
