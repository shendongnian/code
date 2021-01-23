    public class PersonFinder : Disposable
    {
        IMyProj1DbContext _db;
    
        public PersonFinder(IMyProj1DbContext db)
        {
            _db = db;
        }
    
        public Person FindPersonByLocation(Place placeToSearch)
        {
            return _db.People.SingleOrDefault(p => p.Location_Id == placeToSearch.Id);
        }
    
        public void Dispose()
        {
            // ... Proper dispose pattern implementation excluded for brevity
            if (_db != null && _db is Disposable)
                ((Disposable)_db).Dispose();
        }
    }
