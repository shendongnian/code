    Parallel.ForEach(fileNames, 
        (name) => 
        {
            string baseUrl = "http://some url";
            string url = string.Format(baseUrl, fileName);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            var response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            var img = Image.FromStream(stream);
            var fileNameImage = new ImageFileName(fileName.ToString(), img);
            int numIterations = 4;
            for (int i = 0; i < numIterations; i++)
            {
                // Path.Combine() is safer than trying to assemble paths yourself.
                img.Save(Path.Combine("C:\\path", fileName.ToString()));  
                
                // Using local variables - it looked like the original code was using shared
                // properties, which is unsafe in multithreaded code
                // Also, a using block ensures disposal even if there's an exception
                using(var zoomThumbnail = GenerateThumbnail(ZoomThumbnail, 86, false))
                {
                    zoomThumbnail.Save("C:\\path" + imgfilename2.ImageName + "_Thumb.jpg");
                }
                using(var zoomSmall = GenerateThumbnail(ZoomSmall, 400, false))
                {
                    zoomSmall.Save("C:\\path" + imgfilename2.ImageName + "_Small.jpg");
                }
                using(var zoomLarge = GenerateThumbnail(ZoomLarge, 1200, false))
                {
                    ZoomLarge.Save("C:\\path" + imgfilename2.ImageName + "_Large.jpg");
                }
            }
        });
