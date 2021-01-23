    string blobName = "data1";
    string zipName = "database.zip";
    Byte[] blob = (Byte[])reader[blobName];
    using(MemoryStream zs = new MemoryStream())
    {
      // Build the archive
      using(System.IO.Compression.ZipArchive zipArchive = new ZipArchive(zs, ZipArchiveMode.Create, true))
      {
        System.IO.Compression.ZipArchiveEntry archiveEntry = zipArchive.CreateEntry(blobName);
        using(Stream entryStream = archiveEntry.Open())
        {
          entryStream.Write(blob, 0/* offset */, blob.Length);
        }
      }
      
      //Rewind the stream for reading to output.
      zs.Seek(0,SeekOrigin.Begin);
      
      // Write to output.
      Response.Clear();
      Response.ContentType = "application/zip";
      Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", zipName));
      Response.BinaryWrite(zs.ToArray());
      Response.End();
     }
     
