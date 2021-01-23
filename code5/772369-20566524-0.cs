      public void ZipFilesToResponse(HttpResponseBase response, IEnumerable<Asset> files, string zipFileName)
        {
            using (var zipOutputStream = new ZipOutputStream(response.OutputStream))
            {
                zipOutputStream.SetLevel(0); // 0 - store only to 9 - means best compression
                response.BufferOutput = false;
                response.AddHeader("Content-Disposition", "attachment; filename=" + zipFileName);
                response.ContentType = "application/octet-stream";
                foreach (var file in files)
                {
                    var entry = new ZipEntry(file.FilenameSlug())
                    {
                        DateTime = DateTime.Now,
                        Size = file.Filesize
                    };
                    zipOutputStream.PutNextEntry(entry);
                    storageService.ReadToStream(file, zipOutputStream);
                    response.Flush();
                    if (!response.IsClientConnected)
                    {
                       break;
                    }
                }
                zipOutputStream.Finish();
                zipOutputStream.Close();
            }
            response.End();
        }
