     public async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;
            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }
            return dbExist;
        }
        public async Task CreateDatabaseAsync(string dbName)
        {
            SQLiteAsyncConnection con = new SQLiteAsyncConnection(dbName);
            await con.CreateTableAsync<ChatClass>();
           // await con.CreateTableAsync<RecentChatManageClass>();
            await con.CreateTableAsync<PurchasedGift>();
            // await con.CreateTableAsync<AttandanceManagement>();
        }   
