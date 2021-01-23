                  if (entryName.EndsWith(".zip"))
                    {
                        string zipfilename = file.Uri.ToString();
                       dBlob= blobClient.GetBlobReference(file.Uri.ToString()); //url to .zip file 
                    }
                    else
                    {
                        dBlob = blobClient.GetBlobReference(xyzblob); //url to blob folder
                     }
                    zipOutputStream.PutNextEntry(entryName);
                    dBlob.DownloadToStream(zipOutputStream);
