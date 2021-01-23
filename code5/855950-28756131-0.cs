    public async Task<bool> IsDbExists(string fileName)
        {
            try
            {
                var item = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                var db = new SQLiteConnection(DbHelper.DBPATH);
                var tb1 = db.GetTableInfo("Domain");
                var tb2 = db.GetTableInfo("Account");
                var tb3 = db.GetTableInfo("Product");
                var tb4 = db.GetTableInfo("Review");
                if (item == null || tb1.Count == 0 || tb2.Count == 0 || tb3.Count == 0 || tb4.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
