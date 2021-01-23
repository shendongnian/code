                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    //foreach (string file in httpRequest.Files)
                    //{
                    HttpPostedFile postedFile = httpRequest.Files[0];
                    // Initialize the stream.
                    Stream mstream = postedFile.InputStream;
                    byte[] byteArray = new byte[postedFile.ContentLength];
                    postedFile.InputStream.Read(byteArray, 0, postedFile.ContentLength);
