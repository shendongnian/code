    using System.IO;
    if (path.EndsWith("\"))
    {
        path = Directory.GetParent(Directory.GetParent(path)).FullName;
    }
    else
    {
        path = Directory.GetParent(path).FullName;
    }
