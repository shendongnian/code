    IMobileServiceTable<Item> table = App.MobileService.GetTable<Item>();
            var account = table
                .Where(Item => Item.Email == _email_ && Item.Password == _pass_).
                Take(1).ToListAsync();
            List<Item> list = await account;
            list[0].Pursue = pursue;
            await table.UpdateAsync(list[0]);
