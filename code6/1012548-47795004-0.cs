        public ResizedImageWithMetadata GetResizedImageWithMetadata(Stream content,..)
            {
                try
                {
                    if (content == null)
                    {
                        throw new ArgumentNullException($"Image content is empty!");
                    }
                    using (MagickImage image = new MagickImage(content))
                    {
    // unexpected exception...
