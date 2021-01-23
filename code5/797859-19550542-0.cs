            try
            {
                // ....
            }
            catch (WebException webEx)
            {
                string message = string.Empty;
                if (webEx.Response.GetType() == typeof(FtpWebResponse))
                {
                    FtpWebResponse response = (FtpWebResponse)webEx.Response;
                    message = string.Format("{0} - {1}", response.StatusCode, response.StatusDescription);
                } else
                {
                    message = webEx.Message;
                }
                throw new Exception(message);
            }
