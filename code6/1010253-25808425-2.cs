    using Microsoft.VisualBasic;
    string filesplit = "|split|";
    string stub;
    string[] opt;
    FileSystem.FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared);
    stub = Strings.Space(Convert.ToInt32(FileSystem.LOF(1)));
    FileSystem.FileGet(1, ref stub);
    FileSystem.FileClose(1);
    opt = Strings.Split(stub, filesplit);
