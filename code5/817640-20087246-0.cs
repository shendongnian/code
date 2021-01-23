        public class MyCacheItem { ... }
        var resultSet = 
            from p in myEventsDocument.Descendants("event")
            select new MyCacheItem { ... }
        IEnumerable<MyCacheItem> itemCache = (IEnumerable<MyCacheItem>)Cache["eventCache"];
