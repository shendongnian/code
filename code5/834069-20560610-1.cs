    public static bool SaveImage(HttpPostedFile imageUpload, string imagePath, out string error)
    {
        error = "";
        string extension = Path.GetExtension(imageUpload.FileName);
        if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
        {
            try
            {
                System.Drawing.Bitmap objImage = new System.Drawing.Bitmap(imageUpload.InputStream);
                System.Drawing.Bitmap outImage = new Bitmap(170, 200);
                System.Drawing.Graphics outGraphics = Graphics.FromImage(outImage);
                SolidBrush sb = new SolidBrush(System.Drawing.Color.White);
                outGraphics.FillRectangle(sb, 0, 0, 170, 200);
                outGraphics.DrawImage(objImage, 0, 0, 170, 200);
                sb.Dispose();
                outGraphics.Dispose();
                objImage.Dispose();
                outImage.Save(System.Web.HttpContext.Current.Server.MapPath(imagePath));
                return true;
            }
            catch (Exception e)
            {
                error = "Failed to save Image. Error: " + e.Message;
            }
        }
        else
        {
            error = "Invalid image foramt.";
        }
        return false;
    }
