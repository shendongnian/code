    private byte[] LoadByteArrayFromFile(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] byteArray = new byte[fs.Length];
                int bytesRead = 0;
                int bytesToRead = (int)fs.Length;
 
                while (bytesToRead > 0)
                {
                    int read = file.Read(byteArray, bytesRead, bytesToRead);
                    if (read == 0)
                        break;
                    bytesToRead -= read;
                    bytesRead += read;
                }
 
                return byteArray;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
