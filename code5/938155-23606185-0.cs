    IEnumerable<string> EnumerateFiles(string path)
    {
        APIWrapper.FindData findData = new APIWrapper.FindData();
        
        APIWrapper.SafeFindHandle handle = APIWrapper.SafeNativeMethods.FindFirstFile(System.IO.Path.Combine(path, "*"), findData);
        if(!handle.IsInvalid && !handle.IsClosed)
        {
            yield return findData.fileName;
        
            while(!APIWrapper.SafeNativeMethods.FindNextFile(handle, findData))
                yield return findData.fileName;
            handle.Close();
        }
    }
