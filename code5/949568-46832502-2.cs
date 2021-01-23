        /// <summary>
        /// Gets file size from a url using WebClient and Stream classes
        /// </summary>
        /// <param name="address">url</param>
        /// <param name="useHeaderOnly">requests only headers instead of full file</param>
        /// <returns>File size or -1 if their is an issue.</returns>
        static Int64 GetFileSize(string address, bool useHeaderOnly = false)
        {
            Int64 retVal = 0;
            try
            {
                if(useHeaderOnly)
                {
                    WebRequest request = WebRequest.Create(address);
                    request.Method = "HEAD";
                    // WebResponse also has to be closed otherwise we get the same issue of hanging on the connection limit. Using statement closes it automatically.
                    using (WebResponse response = request.GetResponse())
                    {
                        if (response != null)
                        {
                            retVal = response.ContentLength;
                            //retVal =  Convert.ToInt64(response.Headers["Content-Length"]);
                        }
                    }
                    request = null;
                }
                else
                {
                    using (WebClient client = new WebClient())
                    {
                        // Stream has to be closed otherwise we get the issue of hanging on the connection limit. Using statement closes it automatically.
                        using (Stream response = client.OpenRead(address))
                        {
                            retVal = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                retVal = -1;
            }
            return retVal;
        }
