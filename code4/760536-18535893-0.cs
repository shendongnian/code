    public static class FileHasher
    {
        /// <summary>
        /// Gets a files' contents from the given URI and calculates the SHA256 hash
        /// </summary>
        public static byte[] GetFileHash(Uri FileUri)
        {
            using (var Client = new WebClient())
            {
                return SHA256Managed.Create().ComputeHash(Client.OpenRead(FileUri));
            }
        }
    }
