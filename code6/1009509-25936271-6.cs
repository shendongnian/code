      public class CommentDataSource
    {
        private DatabaseHelper db;
        public CommentDataSource(DatabaseHelper databaseHelper)
        {
            this.db = databaseHelper;
        }
        public async Task<long> AddComment(String vat, String comment)
        {
            long id = 0;
            DateTime date = DateTime.Now;
            DbComment dbc = new DbComment(vat, comment, date);
            await db.Conn.InsertAsync(dbc);
            DbComment insertDbc = await db.Conn.Table<DbComment>().ElementAtAsync(await db.Conn.Table<DbComment>().CountAsync() - 1);
            if (insertDbc != null)
            {
                id = insertDbc.Id;
            }
            return id;
        }
        public async void RemoveComment(long idComment)
        {
            DbComment comment = await db.Conn.Table<DbComment>().Where(c => c.Id == idComment).FirstOrDefaultAsync();
            if (comment != null)
            {
                await db.Conn.DeleteAsync(comment);
            }
        }
        public async Task<List<DbComment>> FetchAllComments(String vat)
        {
            return await db.Conn.Table<DbComment>().Where(x => x.VAT == vat).ToListAsync();
        }
    }
