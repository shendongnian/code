    private bool IsFileInUse(string path, FileAccess access = FileAccess.Write)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, access, FileShare.Read)) { }
            }
            catch (IOException e)
            {
                return (Marshal.GetHRForException(e) & 0xFFFF) == 32;
            }
            return false;
        }
