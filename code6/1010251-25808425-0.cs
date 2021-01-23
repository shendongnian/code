    using Microsoft.VisualBasic;
    String stub;
    String[] opt;
    Char filesplit = ',';
    FileSystem.FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared);
    stub = Strings.Space((int)(FileSystem.LOF(1)));
    FileSystem.FileGet(1, stub);
    FileSystem.FileClose(1);
    opt = Strings.Split(stub, filesplit);
