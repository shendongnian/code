    string sPDFPath= "FULL PATH";
      WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(sPDFPath);
                    if (FileBuffer != null)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
