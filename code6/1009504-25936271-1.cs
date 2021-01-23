    public class DatabaseHelper
        {
            private String DB_NAME = "DATABASENAME.db";
    
            public SQLiteAsyncConnection Conn { get; set; }
    
           public DatabaseHelper()
            {
                Conn = new SQLiteAsyncConnection(DB_NAME);
                this.InitDb();
    
            }
    
            public async void InitDb()
            {
                // Create Db if not exist
                bool dbExist = await CheckDbAsync();
                if (!dbExist)
                {
                    await CreateDatabaseAsync();
                }
            }
    
            public async Task<bool> CheckDbAsync()
            {
                bool dbExist = true;
    
                try
                {
                    StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(DB_NAME);
                }
                catch (Exception)
                {
                    dbExist = false;
                }
    
                return dbExist;
            }
    
            private async Task CreateDatabaseAsync()
            {
                //add tables here
                //example: await Conn.CreateTableAsync<DbComment>();
            }
        }
