    string url = @"http://redsox.tcs.auckland.ac.nz/CSS/CSService.svc/";
    string saveLoc = @"/project1/home_image";
    using (WebClient wc = new WebClient())
    {
        byte[] fileBytes = wc.DownloadData(url);
        string fileType = wc.ResponseHeaders[HttpResponseHeader.ContentType];
        
        if (fileType != null)
        {
            switch (fileType)
            {
                case "image/jpeg":
                    saveloc += ".jpg";
                    break;
                case "image/gif":
                    saveloc += ".gif";
                    break;
                case "image/png":
                    saveloc += ".png";
                    break;
                default:
                    break;
            }
            System.IO.File.WriteAllBytes(saveloc, fileBytes);
        }
    }
