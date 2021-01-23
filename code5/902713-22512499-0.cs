    void task_Completed(object sender, Microsoft.Phone.Tasks.PhotoResult e)
    {
        if (e.TaskResult == Microsoft.Phone.Tasks.TaskResult.OK)
        {
            MediaLibrary library = new MediaLibrary();
            Picture pic = library.Pictures.Where(p => e.OriginalFileName.EndsWith("\\" + p.Album.Name + "\\" + p.Name)).FirstOrDefault();
            Stream thumbnailStream = pic.GetThumbnail(); // Stream to a thumbnail
        }
    }
