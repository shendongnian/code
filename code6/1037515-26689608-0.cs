        private bool IsFileTypeValid(HttpPostedFileBase image)
        {
            try
            {
                using (var img = Image.FromStream(image.InputStream))
                {
                    return IsOneOfValidFormats(img.RawFormat);
                }
            }
            finally
            {
                image.InputStream.Seek(0, SeekOrigin.Begin);
            }
        }
