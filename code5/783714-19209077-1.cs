    /// <summary>
    /// Example of tar-cs library usage to extract tar.gz-archives.
    /// Please use the latest version (from trunk) of the library.
    /// </summary>
    public static class TarGZip
    {
        public static void Extract(string inputFile, string outputDirectory)
        {
            using (FileStream inputStream = File.OpenRead(inputFile))
            using (Stream tarStream = UnGZipSteam(inputStream))
            {
                var tarReader = new TarReader(tarStream);
                while (tarReader.MoveNext(false)) // Moves pointer to the next file in the tar archive.
                {
                    ExtractTarEntry(tarReader, outputDirectory);
                }
            }
        }
        /// <summary>
        /// Since GZipStream.Position Property is not implemented,
        /// it is necessary to use MemoryStream as intermediate storage.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <returns>Un-gzipped stream.</returns>
        private static Stream UnGZipSteam(Stream inputStream)
        {
            using (GZipStream gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            {
                MemoryStream memoryStream = new MemoryStream();
                gZipStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
        private static void ExtractTarEntry(TarReader tarReader, string outputDirectory)
        {
            string relativePath = tarReader.FileInfo.FileName;
            // Relative path can contain slash, not backslash.
            // Use Path.GetFullPath() method to convert path.
            string fullPath = Path.GetFullPath(Path.Combine(outputDirectory, relativePath));
            switch (tarReader.FileInfo.EntryType)
            {
                case EntryType.File:
                case EntryType.FileObsolete:
                    using (FileStream outputStream = File.Create(fullPath))
                    {
                        // Read data from a current file to a Stream.
                        tarReader.Read(outputStream);
                    }
                    break;
                case EntryType.Directory:
                    Directory.CreateDirectory(fullPath);
                    break;
                default:
                    throw new NotSupportedException("Not supported entry type: " + tarReader.FileInfo.EntryType);
            }
        }
    }
