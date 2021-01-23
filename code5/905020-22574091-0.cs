                 string url = "http://eample.com";
                string strRef = "http://as.eample.com";
    
                Uri baseUri = new Uri(url); //main URL
                Uri myUri = new Uri(baseUri, strRef); //strRef is new found link
                var domain = baseUri.Host;
                domain = baseUri.Host.Replace("www.", string.Empty).Replace("http://", string.Empty).Replace("https://", string.Empty).Trim();
    
                //hrere is solution
                string[] hostParts = new System.Uri(strRef).Host.Split('.');
                string domain2 = String.Join(".", hostParts.Skip(Math.Max(0, hostParts.Length - 2)).Take(2));
    
                strRef = myUri.ToString();
                if (domain2 == (domain))
                { //DO STUFF 
    
                }
