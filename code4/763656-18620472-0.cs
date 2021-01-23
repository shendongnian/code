    public FileResult Preview(string path) {
    // Database fetch of image details
    try {
        // Get the relative path
        if (!path.IsNull()) {
            // Get the path
            string filePath = path;
            string absolutePath = ...
            // Make sure the the file exists
            if (System.IO.File.Exists(absolutePath)) {
                // Check the preview
                string previewPath = ...;
                // Has preview
                bool hasPreview = true;
                // Check to see if the preview exists
                if (!System.IO.File.Exists(previewPath) || System.IO.File.GetLastWriteTime(previewPath) < System.IO.File.GetLastWriteTime(absolutePath)) {
                    try {
                        // Generate preview
                        hasPreview = ...  != null;
                    }
                    catch (Exception exc) {
                        hasPreview = false;
                    }
                }
                // Once the path is handled, set the type
                if (hasPreview) {
                    return new FileStreamResult(new FileStream(previewPath, FileMode.Open), "image/png");
                }
                // No preview
                else
                    return WriteDefault();
            }
            else
                // Write the default (blank)
                return WriteDefault();
        }
        else {
            return WriteDefault();
        }
    }
    catch {
        // Write the default (no_photo)
        return WriteDefault();
        }
    }
    private FileContentResult WriteDefault() {
        // Write the default
        System.Drawing.Bitmap bmp = new Bitmap(25, 25);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 25, 25);
        bmp = new Bitmap(25, 25, g);
        MemoryStream str = new MemoryStream();
        bmp.Save(str, ImageFormat.Png);
        return File(str.ToArray(), "image/png");
    }
