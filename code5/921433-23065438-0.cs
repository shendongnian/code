    public database_BD GetDate()
    {
        var data = db.database_BD.OrderByDescending(c => c.UploadDate)
                                 .FirstOrDefault(a => a.UploadDate.HasValue);
         return data;
    }
