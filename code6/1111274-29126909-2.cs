    class BaseCrud<T> where T : BaseModel {
        //initialice your db 
        protected SQLite.SQLiteConnection db;
        public bool Delete(T item) {
            return db.Delete<T>(item.Id) > 0;
        }
        public bool Update(T item) {
            return db.Update(item) > 0;
        }
        public bool Insert(T item) {
            return db.Insert(item) > 0;
        }
    }
