     string fileName = "filename" + ".zip";
     MemoryStream stream = new MemoryStream();
     ZipFile zipFile = new ZipFile();     
     WebRequest webRequest = WebRequest.Create(myUrl);
     webRequest.Timeout = 1000;
     WebResponse webResponse = webRequest.GetResponse();
     using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
     {
         string content = reader.ReadToEnd();
         zipFile.AddEntry("myfile.txt", content);
     }
     
     zipFile.Save(stream);
     zipFile.Dispose();
     stream.Seek(0, SeekOrigin.Begin);
     return File(stream, "application/zip", fileName);
