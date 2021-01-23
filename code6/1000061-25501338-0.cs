        public virtual byte[] Compress(XDocument model)
        {
            DebugCheck.NotNull(model);
            using (var outStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(outStream, CompressionMode.Compress))
                {
                    model.Save(gzipStream);
                }
                return outStream.ToArray();
            }
        }
