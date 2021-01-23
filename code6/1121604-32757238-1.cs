         private bool IsDirectoryExists(string path)
        {
            bool isDirectoryExist = false;
            try
            {
                sftp.ChangeDirectory(path);
                isDirectoryExist = true;
            }
            catch (SftpPathNotFoundException)
            {
                return false;
            }
            return isDirectoryExist;
        }
