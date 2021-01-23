    string apkPath = "C:\\app.apk";
    ICSharpCode.SharpZipLib.Zip.ZipInputStream zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(File.OpenRead(apkPath));
    var filestream = new FileStream(apkPath, FileMode.Open, FileAccess.Read);
    ICSharpCode.SharpZipLib.Zip.ZipFile zipfile = new ICSharpCode.SharpZipLib.Zip.ZipFile(filestream);
    ICSharpCode.SharpZipLib.Zip.ZipEntry item;
    
        
     while ((item = zip.GetNextEntry()) != null)
     {
        if (item.Name == "AndroidManifest.xml")
        {
            byte[] bytes = new byte[50 * 1024];
    
            Stream strm = zipfile.GetInputStream(item);
            int size = strm.Read(bytes, 0, bytes.Length);
    
            using (BinaryReader s = new BinaryReader(strm))
            {
                byte[] bytes2 = new byte[size];
                Array.Copy(bytes, bytes2, size);
                AndroidDecompress decompress = new AndroidDecompress();
                content = decompress.decompressXML(bytes);
            }
         }
      }
