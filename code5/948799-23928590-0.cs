    public class CopyFiles {
    
    internal event EventHandler Successful;
    
    internal event EventHandler Failed;
    
    private string Reason;
    
    private string mstrSource;
    
    private string mstrDestination;
    
    internal void StartCopying() {
        try {
            CopyDirectory(mstrSource, mstrDestination);
            Successful();
        }
        catch (Exception ex) {
            Failed(ex.Message);
        }
    }
    
    private bool CopyDirectory(string Src, string Dest) {
        // add Directory Seperator Character (\) for the string concatenation shown later
        if ((Dest.Substring((Dest.Length - 1), 1) != Path.DirectorySeparatorChar)) {
            Dest = (Dest + Path.DirectorySeparatorChar);
        }
        // If Directory.Exists(Dest) = False Then Directory.CreateDirectory(Dest)
        string[] Files = Directory.GetFileSystemEntries(Src);
        foreach (string element in Files) {
            if ((Directory.Exists(element) == true)) {
                // if the current FileSystemEntry is a directory,
                // call this function recursively
                Directory.CreateDirectory((Dest + Path.GetFileName(element)));
                CopyDirectory(element, (Dest + Path.GetFileName(element)));
            }
            else {
                // the current FileSystemEntry is a file so just copy it
                File.Copy(element, (Dest + Path.GetFileName(element)), true);
            }
        }
    }
    
    internal string Source {
        get {
            return mstrSource;
        }
        set {
            mstrSource = value;
        }
    }
    
    internal string Destination {
        get {
            return mstrDestination;
        }
        set {
            mstrDestination = value;
        }
    }
}
