    //include
    dbs.ContactsDB.Include("ExposureResult") or dbs.ContactsDB.Include(er => er.ExposureResult)
    public class ExposureResults {
        public int ID { get; set; }
        public string ExposureResult { get; set; }
        //foreign key property
        public int ContactsID
    }
