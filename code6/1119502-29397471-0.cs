        private void button2_Click(object sender, EventArgs e) {
        {
            List<string> searchResults = SearchCache(textBox1.Text, @"C:\Cache");
            foreach (string file in searchResults)
            {
                //MessageBox popup can be set up here if you like...
                Console.WriteLine(String.Format("Found: {0}", file));
            }
        }
        /// <summary>
        /// Finds all matches to the file name in the search text
        /// </summary>
        /// <param name="searchText">The file path in the search text</param>
        /// <param name="cachePath">The cache path</param>
        /// <returns></returns>
        private List<string> SearchCache(string searchText, string cachePath)
        {
            string[] files = Directory.GetFiles(cachePath, "*.*", SearchOption.AllDirectories);
            Console.WriteLine(String.Format("No. of files in cache: {0}", files.Length));
            List<string> searchResults = new List<string>();
            foreach (string file in files)
                if (AreFileReferencesSame(searchText, file))
                    searchResults.Add(file);
            Console.WriteLine(String.Format("No. of matches: {0}", searchResults.Count));
            return searchResults;
        }
        
        /// <summary>
        /// Checks if the files referenced by a URL and the cache versions are the same
        /// </summary>
        /// <param name="url">Url path</param>
        /// <param name="filePath">Cached file full path</param>
        /// <returns></returns>
        private bool AreFileReferencesSame(string url, string filePath)
        {
            //Extract the file names from both strings
            int lastIndexOfUrl = url.LastIndexOf("/");
            int lastIndexOfPath = filePath.LastIndexOf(@"\");
            
            //Move the marker one ahead if the placeholders are found
            lastIndexOfUrl = lastIndexOfUrl >= 0 ? lastIndexOfUrl + 1 : 0;
            lastIndexOfPath = lastIndexOfPath >= 0 ? lastIndexOfPath + 1 : 0;
            string urlFilename = url.Substring(lastIndexOfUrl).Trim();
            string diskFilename = filePath.Substring(lastIndexOfPath).ToString();
            if (urlFilename.Equals(diskFilename, StringComparison.CurrentCultureIgnoreCase))
                return true;
            else
                return false;
        }
    }
