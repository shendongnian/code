    using (MemoryStream ms = new MemoryStream())
    {
         stream.CopyTo(ms);
         System.IO.File.WriteAllBytes(Server.MapPath("~/Report1.pdf"), ms.ToArray());
    }
