    string path = Path.GetDirectoryName(oldName);
    string name = Path.GetFileNameWithoutExtension(oldName);
    string extension = Path.GetExtensions(oldName);
    var now = DateTime.Now;
    var newName = String.Format("{0} ({1:0000}{2:00}{3:00}-{4:00}{5:00}{6:00}),
        name ,
        now.Year, now.Month, now.Day,
        now.Hour, now.Minute, now.Second);
    System.IO.File.Move(oldname, path + newName + extension);
