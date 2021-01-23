    IReadOnlyList<IStorageFile> files = await picturesFolder.GetFilesAsync(CommonFileQuery.OrderByDate);
    if(files.Count > 0)
    {
        var images = new List<WriteableBitmap>();
        foreach(var f in files)
        { 
             var bitmap = new WriteableBitmap(500, 500);
             using (var stream = await f.OpenAsync(FileAccessMode.ReadWrite))
             {
                 bitmap.SetSource(stream);
             }
             images.Add(bitmap);
        }
    }
