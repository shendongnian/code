    if (f2.Exists)
                {
                    File.Delete(newPath);
                }
                else
                {
                    File.Copy(oldPath, newPath);
                    f2 = new FileInfo(newPath);
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-length", f2.Length.ToString());
                    Response.TransmitFile(newPath);
                    Response.End();
                }
