    public ResizedImageWithMetadata GetResizedImageWithMetadata(Stream content,..)
        {
            try
            {
                if (content == null)
                {
                    throw new ArgumentNullException($"Image content is empty!");
                }
                content.Seek(0, SeekOrigin.Begin); //THIS IS NEEDED!!!
                using (MagickImage image = new MagickImage(content))
                {
