        char[] buffer = new char[2048]; //or 1024 if you want to keep the same block size
        using (var reader = new StreamReader(stream, Encoding.Unicode)) // <= Or whatever encoding the orignal is
        {
            using (var tw = new StreamWriter(DownloadedFilePath, false, Encoding.UTF8)) //streamwriter instead of filestream
            {                
                while (true)
                {
                    int ReadCount = reader.Read(buffer, 0, buffer.Length);
                    if (ReadCount == 0) break;
                    tw.Write(buffer, 0, ReadCount);                    
                }
                ResponseDescription = response.StatusDescription;
                stream.Close();
                tw.Close();
            }
        }
