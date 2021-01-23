     private bool FileUploadCompleted(string filename)
        {
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open,
                    FileAccess.Read,
                    FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
