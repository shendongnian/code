        public ActionResult Details(string id, int type)
        {
           IEnumerable<IEntity> collection1 = ASR.Albums;
           IEnumerable<IEntity> collection2 = TSR.Tracks;
           var collectionToUse = (type == 1) ? collection1 : collection2;
           
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
