    public static class FileUpload
    {
            public static char DirSeparator = System.IO.Path.DirectorySeparatorChar;
            public static string FilesPath = HttpContext.Current.Server.MapPath("~\\Content" + DirSeparator + "Uploads" + DirSeparator);
    
            public static string UploadFile(HttpPostedFileBase file)
            {
                // Check if we have a file
                if (null == file) return "";
                // Make sure the file has content
                if (!(file.ContentLength > 0)) return "";
    
                string fileName =DateTime.Now.Millisecond+ file.FileName;
                string fileExt = Path.GetExtension(file.FileName);
    
                // Make sure we were able to determine a proper extension
                if (null == fileExt) return "";
    
                // Check if the directory we are saving to exists
                if (!Directory.Exists(FilesPath))
                {
                    // If it doesn't exist, create the directory
                    Directory.CreateDirectory(FilesPath);
                }
    
                // Set our full path for saving
                string path = FilesPath + DirSeparator + fileName;
    
                // Save our file
                file.SaveAs(Path.GetFullPath(path));
    
                // Save our thumbnail as well
                ResizeImage(file, 70, 70);
    
                // Return the filename
                return fileName;
            }
    
            public static void DeleteFile(string fileName)
            {
                // Don't do anything if there is no name
                if (fileName.Length == 0) return;
    
                // Set our full path for deleting
                string path = FilesPath + DirSeparator + fileName;
                string thumbPath = FilesPath + DirSeparator + "Thumbnails" + DirSeparator + fileName;
    
                RemoveFile(path);
                RemoveFile(thumbPath);
            }
    
            private static void RemoveFile(string path)
            {
                // Check if our file exists
                if (File.Exists(Path.GetFullPath(path)))
                {
                    // Delete our file
                    File.Delete(Path.GetFullPath(path));
                }
            }
    
            public static void ResizeImage(HttpPostedFileBase file, int width, int height)
            {
                string thumbnailDirectory = String.Format(@"{0}{1}{2}", FilesPath, DirSeparator, "Thumbnails");
    
                // Check if the directory we are saving to exists
                if (!Directory.Exists(thumbnailDirectory))
                {
                    // If it doesn't exist, create the directory
                    Directory.CreateDirectory(thumbnailDirectory);
                }
    
                // Final path we will save our thumbnail
                string imagePath = String.Format(@"{0}{1}{2}", thumbnailDirectory, DirSeparator, file.FileName);
                // Create a stream to save the file to when we're done resizing
                FileStream stream = new FileStream(Path.GetFullPath(imagePath), FileMode.OpenOrCreate);
    
                // Convert our uploaded file to an image
                Image OrigImage = Image.FromStream(file.InputStream);
                // Create a new bitmap with the size of our thumbnail
                Bitmap TempBitmap = new Bitmap(width, height);
    
                // Create a new image that contains are quality information
                Graphics NewImage = Graphics.FromImage(TempBitmap);
                NewImage.CompositingQuality = CompositingQuality.HighQuality;
                NewImage.SmoothingMode = SmoothingMode.HighQuality;
                NewImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
                // Create a rectangle and draw the image
                Rectangle imageRectangle = new Rectangle(0, 0, width, height);
                NewImage.DrawImage(OrigImage, imageRectangle);
    
                // Save the final file
                TempBitmap.Save(stream, OrigImage.RawFormat);
    
                // Clean up the resources
                NewImage.Dispose();
                TempBitmap.Dispose();
                OrigImage.Dispose();
                stream.Close();
                stream.Dispose();
            }
