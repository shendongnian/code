    public string GetCompleteFolderName(Folder folder)
    {
        string folderName = string.Empty;
        if(FolderParent != null)
        {
            folderName += GetCompleteFolderName(FolderParent) + _delimiter + this._folderName;
        }
        else
        {
            folderName += this._folderName;
        }
        return folderName;
    }
