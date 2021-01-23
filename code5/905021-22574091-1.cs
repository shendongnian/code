                string url = "http://www.xxx.co.uk";
                string strRef = "http://www.news.xxx.co.uk";
    
                Uri baseUri = new Uri(url); //main URL
                Uri myUri = new Uri(baseUri, strRef); //strRef is new found link
                var domain = baseUri.Host;
                domain = baseUri.Host.Replace("www.", string.Empty).Replace("http://", string.Empty).Replace("https://", string.Empty).Trim();
    
                //hrere is solution
    
                string domain2 = GetDomainName(strRef);
    
                strRef = myUri.ToString();
                if (domain2 == (domain))
                { //DO STUFF 
    
                }
              
    
    
       private static string GetDomainName(string url)
            {
                string domain = new Uri(url).DnsSafeHost.ToLower();
                var tokens = domain.Split('.');
                if (tokens.Length > 2)
                {
                    //Add only second level exceptions to the < 3 rule here
                    string[] exceptions = { "info", "firm", "name", "com", "biz", "gen", "ltd", "web", "net", "pro", "org" };
                    var validTokens = 2 + ((tokens[tokens.Length - 2].Length < 3 || exceptions.Contains(tokens[tokens.Length - 2])) ? 1 : 0);
                    domain = string.Join(".", tokens, tokens.Length - validTokens, validTokens);
                }
                return domain;
            }
