    string text = GetLongText();
    byte[] ba = Encoding.UTF8.GetBytes(text);
    using (MemoryStream ms = new MemoryStream())
    {
        using (ZipStorer zip = ZipStorer.Create(ms, "My Zip"))
        {
            zip.AddStream(ZipStorer.Compression.Deflate, "text.txt", new MemoryStream(ba), DateTime.Now, "My Text");
        }
        Response.AppendHeader("content-disposition", "attachment; filename=MyZip.zip");
        Response.ContentType = "application/zip";
        Response.BinaryWrite(ms.ToArray());
        Response.End();
    }
    }
