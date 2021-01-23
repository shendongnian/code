        protected static Bitmap ByteArrayToBitmap(byte[] blob)
        {
            using (var mStream = new MemoryStream())
            {
                mStream.Write(blob, 0, blob.Length);
                mStream.Position = 0;
                try
                {
                    var bm = new Bitmap(mStream);
                    return bm;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Not a valid bitmap.", "blob", ex);
                }
            }
        }
