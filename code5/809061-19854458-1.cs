    interface IDBRequest<T>
    {
        IQueryable<T> Exec();
    }
    class DBRequest1 : IDBRequest<Models.Table1Element>
    {
        public IQueryable<Models.Table1Element> Exec()
        {
            return Enumerable.Empty<Models.Table1Element>().AsQueryable();
        }
    }
    class DBRequest2 : IDBRequest<Models.Table1Element>
    {
        public IQueryable<Models.Table1Element> Exec()
        {
            // fetch from DB
            return MY_DATABASE.Table2.Where(r=>r.id == Id);
        }
    }
