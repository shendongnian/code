     public class SearchInGoogle
    {
        GoogleEntities db = new GoogleEntities();
        object dbLock = new object();
        public void FindOdd()
        {
    
            List<tbl_search> _oddSearchList = db.tbl_search.Where(c => (c.id % 2) != 0).ToList();
            var client = new GwebSearchClient("http://www.google.com");
    
            foreach (var item in _oddSearchList)
            {
                var results = client.Search(item.title, 1);
    
                tbl_search _saveSearchResult = _oddSearchList.First(x => x.id == item.id);
                _saveSearchResult.result = results.First().ToString();
               
                lock(dbLock)
                {
                    db.SaveChanges();
                }
            }
    
        }
    
        public void FindEven()
        {
    
            List<tbl_search> _evenSearchList = db.tbl_search.Where(c => (c.id % 2) == 0).ToList();
            var client = new GwebSearchClient("http://www.google.com");
            foreach (var item in _evenSearchList)
            {
                var results = client.Search(item.title, 1);
                tbl_search _saveSearchResult = _evenSearchList.First(x => x.id == item.id);
                _saveSearchResult.result = results.First().ToString();
                lock(dbLock)
                {
                    db.SaveChanges();
                }
            }
    
    
        }
    }
