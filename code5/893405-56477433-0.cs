    string path = Server.MapPath(@"/Content/");             
    path = Path.Combine(path,DateTime.Now.ToString('ddmmyyyy'));
    if (!Directory.Exists(path))
      {
         Directory.CreateDirectory(path);
      }
