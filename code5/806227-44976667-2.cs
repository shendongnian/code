        /// <summary>
        /// Compute and assign the MD5 hash of the content.
        /// </summary>
        /// <param name="httpContent"></param>
        /// <returns></returns>
        public static async Task AssignMd5Hash(this HttpContent httpContent)
        {
            var hash = await httpContent.ComputeMd5Hash();
            httpContent.Headers.ContentMD5 = hash;
        }
        /// <summary>
        /// Compute the MD5 hash of the content.
        /// </summary>
        /// <param name="httpContent"></param>
        /// <returns></returns>
        public static async Task<byte[]> ComputeMd5Hash(this HttpContent httpContent)
        {
            using (var md5 = MD5.Create())
            {
                var content = await httpContent.ReadAsStreamAsync();
                var hash = md5.ComputeHash(content);
                return hash;
            }
        }
