    private void btnUpload_Click(object sender, RoutedEventArgs  e)
    {
        //First, convert the image to byte array so we can proceed.
        MemoryStream mStream = new MemoryStream();
        //WriteableBitmap wbmp = new WriteableBitmap(bmp);
        //wbmp.SaveJpeg(mStream, wbmp.PixelWidth, wbmp.PixelHeight, 0, 100);
        mStream.Seek(0, SeekOrigin.Begin);
        var data = mStream.GetBuffer();
			    this.UploadImage(
				    data,
				    (url) =>
				    {
                                            // this will be called on success result
					    lblImageURL.Visibility = System.Windows.Visibility.Visible;
					    lblImageURL.Text = url;
				    },
				    () =>
				    {
                                              
					     // display some error message to user that image failed to upload
				    });
    }
	public void UploadImage(byte[] content, Action<string> onCompletion, Action onError)
    {
        string boundary = Guid.NewGuid().ToString();
        string header = string.Format("--{0}", boundary);
        string footer = string.Format("--{0}--", boundary);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.imgur.com/3/upload");
        request.Method = "POST";
        request.Headers["Authorization"] = "Client-ID " + clientID;
        request.ContentType = "multipart/form-data, boundary=" + boundary;
        StringBuilder builder = new StringBuilder();
        string base64string = Convert.ToBase64String(content);
        builder.AppendLine(header);
        builder.AppendLine("Content-Disposition: form-data; name=\"image\"");
        builder.AppendLine();
        builder.AppendLine(base64string);
        builder.AppendLine(footer);
        byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
        //**BEGIN AREA THAT IS BEING SKIPPED FOR SOME REASON**
        request.BeginGetRequestStream((result) =>
            {
                using (Stream s = request.EndGetRequestStream(result))
                {
                    s.Write(data, 0, data.Length);
                }
                request.BeginGetResponse((respResult) =>
                    {
                        try
                        {
                            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(respResult);
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                var imageURL = reader.ReadToEnd();
                                Regex regex = new Regex(@"https?://([-\w\.]+)+(:\d+)?(/([-\w/_\.]*(\?\S+)?)?)?");
                                MatchCollection matches = regex.Matches(imageURL);
                                foreach (Match match in matches)
                                {
                                    var finalImageURL = match.Value;
	                                onCompletion(finalImageURL);
                                }
                            }
                        }
                        catch (WebException ex)
                        {
                            using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                            {
	                            onError();
                                imageURL = "An uploading error occured. Please check your connection.";
                            }
                        }
                    }, null);
            }, null);
    }
 
