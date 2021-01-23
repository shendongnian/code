        public string getUrl(string url)
        {
            string result;
            string extension = System.IO.Path.GetExtension(url);
            result = Regex.Replace(url, "_ZM(\\d{0,2})", "");
            return result;
        }
