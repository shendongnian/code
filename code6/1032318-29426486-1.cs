    using (webRes = webReq.GetResponse())
    {
        using (sr = webRes.GetResponseStream())
        {
            // continuously read images from the response stream until error
            while (true)
            {
                try
                {
                    // note: the line below probably won't work, you may need to parse
                    // the next image from the multi-part response stream manually
                    image.Image = Image.FromStream(sr);
                    // if the above doesn't work, then do something like this:
                    // var imageBytes = ParseNextImage(sr);
                    // var memoryStream = new MemoryStream(imageBytes);
                    // image.Image = Image.FromStream(memoryStream);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Aborting read from response stream due to error {0}", e);
                    break;
                }
            }
        }
    }
