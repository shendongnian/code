       public static string GetPictureUrl(string faceBookId)
            {
               
                WebResponse response = null;
                string pictureUrl = string.Empty;
                try
                {
                    WebRequest request = WebRequest.Create(string.Format("https://graph.facebook.com/{0}/picture?width=320&height=320", faceBookId));
                    response = request.GetResponse();
                    pictureUrl = response.ResponseUri.ToString();
                }
                catch (Exception ex)
                {
                    //? handle
                }
                finally
                {
                    if (response != null) response.Close();
                }
                return pictureUrl;
            }
