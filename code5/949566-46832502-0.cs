        /// <summary>
        /// Gets file size from a url using WebClient and Stream classes
        /// </summary>
        /// <param name="address">url</param>
        /// <returns>File size or -1 if their is an issue.</returns>
        public static Int64 GetFileSize(string address)
        {
            Int64 retVal = 0;
            try
            {
                using (var client = new WebClient())
                {
                    Stream stream = client.OpenRead(address);
                    retVal = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                retVal = -1;
            }
            return retVal;
        }
