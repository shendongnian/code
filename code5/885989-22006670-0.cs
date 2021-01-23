    public bool IsValidGDIPlusImage(string filename)
    {
        try
        {
            using (var bmp = new Bitmap(filename))
            {
            }
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
