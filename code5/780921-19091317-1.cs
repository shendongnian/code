    if (File.Exists(files[k].ToString()))
    {
        using(System.Drawing.Image originalimg = System.Drawing.Image.FromFile(files[k].ToString()))
        {
            using(System.Drawing.Image thumbnail = originalimg.GetThumbnailImage(110, 110, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
            {
                usingSystem.Drawing.Image smallsize = originalimg.GetThumbnailImage(47, 47, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
                {
                    string SaveLocation1 = Server.MapPath("../imgres/products") + "\\Thumbnail\\" + Path.GetFileName(files[k].ToString());
                    thumbnail.Save(SaveLocation1);
        
                    SaveLocation1 = Server.MapPath("../imgres/products") + "\\smallsize\\" + Path.GetFileName(files[k].ToString());
                    smallsize.Save(SaveLocation1);
                }
            }
        }
    }
