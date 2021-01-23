    byte[] fileData = new byte[file.InputStream.Length];
    file.InputStream.Read(fileData, 0, Convert.ToInt32(file.InputStream.Length));
    using (var dataContext = new FileStreamDbContext())
    {
        var entity = new DataFile
        {
            FileName = Path.GetFileName(file.FileName),
            FileExtension = Path.GetExtension(file.FileName),
            FileData = fileData,
        };
        dbContext.Create(entity);
        dbContext.SaveChanges();
    }
