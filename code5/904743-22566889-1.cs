        /// <summary>
        /// Reads a file into a byte array
        /// </summary>
        /// <param name="filePath">Full path of file to read.</param>
        /// <returns>Byte array with file contents.</returns>
        public static byte[] GetFileBytes(string filePath)
        {
            byte[] fileBytes = null;
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var memStr = new MemoryStream())
            {
                byte[] buffer = new byte[4096];
                memStr.Position = 0;
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStr.Write(buffer, 0, bytesRead);
                }
                memStr.Position = 0;
                fileBytes = memStr.GetBuffer();
            }
            return fileBytes;
        } 
