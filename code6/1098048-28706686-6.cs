    public static class FileFolderDialog
    {
        public static FileFolderDialogBase Create(string type)
        {
            swich (type.ToLowerInvariant()) {
                case "folder":
                case "dir":
                case "directory":
                    return new FolderDialog();
                default:
                    return new FileDialog();
            }
        } 
    }
