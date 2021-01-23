    using (var mem = new MemoryStream())
    {
       using(var str = new GZipStream(mem, CompressionMode.Compress))
       {
          WriteMyDataToStream(str);
          str.Flush();
          context.Response.AddHeader("Content-Type", "application/octet-stream");
          context.Response.AddHeader("Content-Disposition","attachment; filename=file.zip");
          mem.WriteTo(context.Response.OutputStream);
       }
    }
