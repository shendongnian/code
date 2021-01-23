    public static bool IsFileLocked(string fileName)
            {
                FileStream stream = null;
                try
                {
                    stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (IOException)
                {
                    return true;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                return false;
            }
