    interface IDBRequest<T>
    {
        IEnumerable<T> Exec();
    }
    class DBRequest1 : IDBRequest<Models.Table1Element>
    {
        public IEnumerable<Models.Table1Element> Exec()
        {
            return Enumerable.Empty<Models.Table1Element>();
        }
    }
    class DBRequest2 : IDBRequest<Models.Table1Element>
    {
        public IEnumerable<Models.Table1Element> Exec()
        {
            // fetch from DB
            return MY_DATABASE.Table2.Where(r=>r.id == Id);
        }
    }
