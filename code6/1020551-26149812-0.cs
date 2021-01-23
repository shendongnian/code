    public class RecordVM
    {
        public HEADER_RECORD header { get; set; }
        public HEADER_EXTENSION_RECORD ext { get; set; }
    }
    return View(new RecordVM { header = db.HEADER_RECORD, ext = db.HEADER_EXTENSION_RECORD });
