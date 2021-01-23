    using System;
    using System.IO;
    using System.Web;
    using ICSharpCode.SharpZipLib.Zip;
    
    public class ZipHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
    
        public void ProcessRequest(HttpContext ctx)
        {
            var path = HttpUtility.UrlDecode(ctx.Request.QueryString["folder"]);
            if (path == null)
            {
                return;
            }
            var folderName = Path.GetFileName(path);
            if (folderName == String.Empty)
            {
                folderName = "root";
            }
    
            int folderOffset = ctx.Server.MapPath("~").Length;
    
            using (var zipStream = new ZipOutputStream(ctx.Response.OutputStream))
            {
                ctx.Response.Clear();
                ctx.Response.BufferOutput = false;
                ctx.Response.AddHeader("Content-Disposition", "attachment; filename=" + folderName + ".zip");
                ctx.Response.AddHeader("Content-Type", "application/zip");
    
                zipStream.SetLevel(3);
    
                CompressFolder(path, zipStream, folderOffset);
    
                ctx.Response.Flush();
            }
        }
    
        private static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string filename in files)
            {
                try
                {
                    using (var streamReader = File.OpenRead(filename))
                    {
                        var fi = new FileInfo(filename);
    
                        string entryName = filename.Substring(folderOffset);
                        entryName = ZipEntry.CleanName(entryName);
    
                        var newEntry = new ZipEntry(entryName)
                        {
                            DateTime = fi.LastWriteTime,
                            Size = fi.Length
                        };
    
                        zipStream.PutNextEntry(newEntry);
    
                        streamReader.CopyTo(zipStream, 4096);
    
                        zipStream.CloseEntry();
                    }
                }
                catch (IOException) { }
            }
    
            var folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }
    }
