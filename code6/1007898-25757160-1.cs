    private List<FileSignature> movedList = new List<FileSignature>();
    private void Watcher1_OnChange()
    {
        ....
        case Delete:
            FileSignature singature = new FileSignature();
            FileInfo info = new System.IO.FileInfo(e.FullPath);
            signature.FileSize = info.Length;
            signature.ModifiedDate = info.LastWriteTime;
            singature.FileType = info.Extension;
            signature.OldFileName = e.FullPath;
            movedList.Add(signature);
            break;
    
    }
