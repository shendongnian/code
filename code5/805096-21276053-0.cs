    using System.IO;    
    ...
    string metaStr = string.Empty;
    
                using (FileStream fs = File.OpenRead(wmaUrl))
                {
                    byte[] b = new byte[3000];
                    
                    fs.Read(b, 0, b.Length);
    
                    metaStr = Encoding.UTF8.GetString(b, 0, 3000);                
                    metaStr = metaStr.Replace("\0", "");
    
                    int metaStart = metaStr.IndexOf("<?xml version");
                    metaStr = metaStr.Substring(metaStart);
    
                    int metaEnd = metaStr.IndexOf("</recordingDetails>");
                    metaStr = metaStr.Substring(0, metaEnd) + "</recordingDetails>";               
                }
