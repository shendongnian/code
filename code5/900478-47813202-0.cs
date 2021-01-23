    public void UnZipp(string srcDirPath, string destDirPath)
    {
            ZipInputStream zipIn = null;
            FileStream streamWriter = null;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destDirPath));
                zipIn = new ZipInputStream(File.OpenRead(srcDirPath));
                ZipEntry entry;
                while ((entry = zipIn.GetNextEntry()) != null)
                {
                    string dirPath = Path.GetDirectoryName(destDirPath + entry.Name);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    streamWriter = File.Create(destDirPath + entry.Name);
                    int size = #DEFINE#;//2048
                    byte[] buffer = new byte[size];
                    while ((size = zipIn.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        streamWriter.Write(buffer, 0, size);
                    }
                    streamWriter.Close();
                }
            }
            catch (System.Threading.ThreadAbortException lException)
            {
                // do nothing
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (zipIn != null)
                {
                    zipIn.Close();
                }
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }
