    IEnumerable<DirectoryInfo> temp = DirInfo.EnumerateDirectories(".", SearchOption.AllDirectories);
    if(excludeSystem) {
        temp = temp.Where((x.Attributes&FileAttributes.System) == 0);
    }
    if(excludeHidden) {
        temp = temp.Where((x.Attributes&FileAttributes.Hidden) == 0);
    }
    if(excludeReadOnly) {
        temp = temp.Where((x.Attributes&FileAttributes.ReadOnly) == 0);
    }
    GetDirsToCopy = temp;
