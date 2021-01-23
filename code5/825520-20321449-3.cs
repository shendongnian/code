    using System.IO;
    var path = String.Format("~/{0}/", USER_ID)
    var folder = Server.MapPath(path)
    if (!Directory.Exists(folder))
    {
         Directory.CreateDirectory(folder);
    }
    System.IO.File.WriteAllBytes(Path.Combine(Server.MapPath(path), fileName), fileBytes)
