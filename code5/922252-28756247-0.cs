    public async Task<bool> IsDbExists(string fileName)
        {
            try
            {
                var item = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                var db = new SQLiteConnection("Your db path");
                var tb1 = db.GetTableInfo("TableName1");
                var tb2 = db.GetTableInfo("TableName2");
                var tb3 = db.GetTableInfo("TableName3");
                var tb4 = db.GetTableInfo("TableName4");
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
