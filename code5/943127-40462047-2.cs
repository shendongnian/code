    public string httpRequest(string url,byte[] image)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "Post";
                    request.ContentType = "multipart/form-data";
                    request.ContentLength = image.Length;
                    using (Stream postStream = request.GetRequestStream())
                    {
                        postStream.Write(image, 0, image.Length);
                        postStream.Close();
                        WebResponse response = request.GetResponse();
                        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        if (!string.IsNullOrEmpty(responseString))
                            return responseString;
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
