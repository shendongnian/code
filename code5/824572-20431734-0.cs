    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsLoggedIn())
            Response.Redirect("/login.aspx");
        else
        {
            // this is dco album id, find out what photosetId it maps to
            string albumId = Request.Params["id"];
            Album album = findAlbum(new Guid(albumId));
            Flickr flickr = FlickrInstance();
            PhotosetPhotoCollection photos = flickr.PhotosetsGetPhotos(album.PhotosetId, PhotoSearchExtras.OriginalUrl | PhotoSearchExtras.Large2048Url | PhotoSearchExtras.Large1600Url);
            Response.Clear();
            Response.BufferOutput = false;
            // ascii only
            //string archiveName = album.Title + ".zip";
            string archiveName = "photos.zip";
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + archiveName);
            int picCount = 0;
            string picNamePref = album.PhotosetId.Substring(album.PhotosetId.Length - 6);
            using (ZipFile zip = new ZipFile())
            {
                zip.CompressionMethod = CompressionMethod.None;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                zip.ParallelDeflateThreshold = -1;
                _map = new Dictionary<string, string>();
                foreach (Photo p in photos)
                {
                    string pictureUrl = p.Large2048Url;
                    if (string.IsNullOrEmpty(pictureUrl))
                        pictureUrl = p.Large1600Url;
                    if (string.IsNullOrEmpty(pictureUrl))
                        pictureUrl = p.LargeUrl;
                    string pictureName = picNamePref + "_" + (++picCount).ToString("000") + ".jpg";
                    _map.Add(pictureName, pictureUrl);
                    zip.AddEntry(pictureName, processPicture);
                }
                zip.Save(Response.OutputStream);
            }
            Response.Close();
        }
    }
    private volatile Dictionary<string, string> _map;
    protected void processPicture(string pictureName, Stream output)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_map[pictureName]);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (Stream input = response.GetResponseStream())
            {
                byte[] buf = new byte[8092];
                int len;
                while ( (len = input.Read(buf, 0, buf.Length)) > 0)
                    output.Write(buf, 0, len);
            }
            output.Flush();
        }
    }
