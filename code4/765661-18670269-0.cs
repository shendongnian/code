        internal bool SaveBytesToFile(string fileFullPath, byte[] stream)
        {
            if (stream.Length == 0) return false;
            try
            { 
                try
                {
                    using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
                    {
                        fileStream.Write(stream, 0, stream.Length);
                    }
                }
                catch (Exception ex)
                {
                    //Write Error log
                    errorhandler.Write(ex);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                //Write Error log
                errorhandler.Write(ex);
                return false;
            }
        }
        internal byte[] StringToBytes(string streamString)
        {
            return Convert.FromBase64String(streamString);
        }
        internal string BytesToString(byte[] stream)
        {
            return Convert.ToBase64String(stream);
        }
