    using System.IO;
    string path = String.Format("~/{0}/", USER_ID);
    string folder = Server.MapPath(path);
    if (!Directory.Exists(folder))
    {
         Directory.CreateDirectory(folder);
    }
    System.IO.File.WriteAllBytes(Path.Combine(Server.MapPath(path), fileName), fileBytes);
