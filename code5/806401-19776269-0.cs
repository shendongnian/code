        public byte[] GetThumbnail(string uri)
        {
            string path = @"D:\Templates\HtmlServiceImage.jpg";
            if (File.Exists(path))
                File.Delete(path);
            if (string.IsNullOrEmpty(uri))
            {
                return null;
            }
            else
            {
                if ((uri.IndexOf("file:", System.StringComparison.Ordinal) < 0) &&
                    (uri.IndexOf("http", System.StringComparison.Ordinal) < 0))
                    uri = "http://" + uri;
                Thumbnail.Uri = uri;
                try
                {
                    Bitmap bitmap =
                        HtmlToThumbnail.WebsiteThumbnail.GetThumbnail(Thumbnail.Uri, Thumbnail.Width,
                                                                      Thumbnail.Hight, Thumbnail.ThumbWidth,
                                                                      Thumbnail.ThumbHight); //);
                    MemoryStream ms = new MemoryStream();
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
                    return ms.ToArray();
                }
                catch (Exception)
                {
                    throw;
                }
                return null;
            }
        }
