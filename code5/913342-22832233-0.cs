    string sourceFile = System.Web.HttpContext.Current.Server.MapPath(Path.Combine("/", "yourAddress"));
    byte[] byteArray = System.IO.File.ReadAllBytes(sourceFile);
    MemoryStream mem;
            using (mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                return mem;
            }
