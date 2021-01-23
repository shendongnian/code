        public interface IExternalIds
        {
            public IEnumerable<SomeType> ExternalIds { get; }
        }
        public class Album: IExternalIds
        {
            ...
        }
        public class Track: IExternalIds
        {
            ...
        }
        public ActionResult Details(string id, int type)
        {
           IEnumerable<Album> collection1 = ASR.Albums;
           IEnumerable<Track> collection2 = TSR.Tracks;
           var collectionToUse = ((type == 1) ? collection1 : collection2)
            as IEnumerable<IExternalIds>;
           foreach (var item in collectionToUse)
           {
               var result = item.ExternalIds.SingleOrDefault(x => x.Id == id);
               if (result != null)
               {
                   return View(item);
               }
           }
           return View();
        }
