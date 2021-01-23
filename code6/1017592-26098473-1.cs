    public static string GetExcelFileOwner(string path) {
        string uspath = Path.Combine(Path.GetDirectoryName(path), "~$" + Path.GetFileName(path));
        if (!File.Exists(uspath)) return "";
        var sharing = FileShare.ReadWrite | FileShare.Delete;
        using (var fs = new FileStream(uspath, FileMode.Open, FileAccess.Read, sharing))
        using (var br = new BinaryReader(fs, Encoding.Default)) {
            return br.ReadString();
        }
    }
