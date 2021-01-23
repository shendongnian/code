     public List<BlobEntity> GetBlobs()
        {
            List<BlobEntity> blobs = null;
            using (var db = new MyDBEntities())
            {
                blobs = (from b in db.blobs
                         where b.id > 0 //Example filter
                         select new BlobEntity
                         {
                             ID = b.id,
                             CompanyName = b.name_company
                         }
                         ).ToList();
            }
            return blobs;
        }
       public static SelectList GetBlobsSelectList()
        {
            MyBL theBL = new MyBL();
            List<BlobEntity> blobEntites = theBL.GetBlobs();
            var listItems = blobEntites
                 .Select(x => new SelectListItem { Text = x.CompanyName,
                                                    Value = x.ID.ToString()
                                                 })
                 .ToList();
            SelectList blobsSelectList = new SelectList(listItems.AsEnumerable(), "Value", "Text");
            return blobsSelectList;
        }
       public class BlobEntity
       {
           public int ID { get; set; }
           public string CompanyName { get; set; }
       }
