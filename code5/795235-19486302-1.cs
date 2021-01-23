      protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            Boolean status = false;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                status = false ;
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                status = true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        
            //file is not locked
            return status;
        }
