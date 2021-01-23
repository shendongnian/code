    using(var db = new AlmostafaDataLinqDataContext())
    {
        byte[] data = System.IO.File.ReadAllBytes(FilePath);
        db.pEditImage(RecordID, data);
        db.SubmitChanges();
    }
