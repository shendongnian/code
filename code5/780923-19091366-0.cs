    using (Image originalimg = Image.FromFile(files[k].ToString()))
    {
       using (Image thumbnail = originalimg.GetThumbnailImage(110, 110, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
       {
          thumbnail.Save(...);
       }
       using (Image smallsize = originalimg.GetThumbnailImage(47, 47, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
       {
          smallsize.Save(...);
       }
    }
        
    
