    public static bool updatetbl1(tbl1 obj, string Album, string Song)
    {
        ABC.Models.tbl1 objmain = new Models.mainISRC();
        using (ABCManagementDBEntities1 dbcontect = new ABCManagementDBEntities1())
        {
            var zz = (from z in dbcontect.tbl1 
                  where z.Album == Album && z.Song == Song select z
                 ).SingleOrDefault();
            zz.Mood = obj.Mood;
            zz.Online = obj.Online;
            zz.Radio = obj.Radio;
            dbcontect.Entry(zz).State = EntityState.Modified;
            dbcontect.SaveChanges();
            return true;
        }
        return false;
    }
