    public class ShortLink
    {
        public string DomainName { get; set; }
        public List<string> UrlList;
    
        public ShortLink(string domainName)
        {
            DomainName = domainName;
            UrlList = new List<string>();
        }
    
        public void AddUrl(string url)
        {
            if(!UrlList.Contains(url))
                UrlList.Add(url);
        }
    
        public string GetFullUrl(int indexOfUrlInList)
        {
            return DomainName + "/" + UrlList[indexOfUrlInList];
        }
    
        //Add other methods like remove and stuff
    }
