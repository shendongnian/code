        public Task UpdateAsync(MyTable entity)
        {
           SQLiteAsyncConnection conn = new SQLiteAsyncConnection(path);
           return conn.UpdateAsync(entity); 
        }
