    if (img != null)
    {
        lock (img)
        {
            if (img != null)
            {
                Bitmap tempImg = (Bitmap)img.Clone();
            }
        }
    }
