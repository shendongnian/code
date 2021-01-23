     string str = getUrl("http://www.example.com/images/item001_ZM80.jpg");
     string str1 = getUrl("http://www.example.com/images/item001_ZM80_AL30.jpg");
            
    public string getUrl(string url)
    {
         string result;
         string extension = System.IO.Path.GetExtension(url);
                if (Regex.Match(url, "_ZM(.*)_").Success)
                {
    
                    result = Regex.Replace(url, "_ZM(.*)_", "_");
                }
                else
                {
                    result = Regex.Replace(url, "_ZM(.*)", "") + extension;
                }
        return result;
    }
