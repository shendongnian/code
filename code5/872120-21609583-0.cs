    if(newPhotoUrl==dbPhotoUrl){
        Access Granted !
    }
    /// <summary>
    /// Returns the base64 encoded string representation of the given image.
    /// </summary>
    /// <param name="image">A System.Drawing.Image to encode as a string.</param>
    string ImageToBase64String(Image image)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            image.Save(stream, image.RawFormat);
            return Convert.ToBase64String(stream.ToArray());
        }
    }
    
    /// <summary>
    /// Creates a new image from the given base64 encoded string.
    /// </summary>
    /// <param name="base64String">The encoded image data as a string.</param>
    Image ImageFromBase64String(string base64String)
    {
        using (MemoryStream stream = new MemoryStream(
            Convert.FromBase64String(base64String)))
        using (Image sourceImage = Image.FromStream(stream))
        {
            return new Bitmap(sourceImage);
        }
    }
