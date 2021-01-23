    byte[] bytearr = webClient.DownloadData(imagePath);    
    var filecontent = new ByteArrayContent(bytearr);
            // request.ContentLength = 0;
            if (filecontent != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(filecontent);
                }
            }
