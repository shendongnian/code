    // Creating a list array
    public List<string> ImageList; 
    public void GetAllImages()
    {
        // Declaring 'x' as a new WebClient() method
        WebClient x = new WebClient();
        // Setting the URL, then downloading the data from the URL.
        string source = x.DownloadString(@"http://www.google.com");
        
        // Declaring 'document' as new HtmlAgilityPack() method
        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        // Loading document's source via HtmlAgilityPack
        document.LoadHtml(source);
        
        // For every tag in the HTML containing the node img.
        foreach(var link in document.DocumentNode.Descendants("img")
                                    .Select(i => i.Attributes["src"])) 
        {
            // Storing all links found in an array.
            // You can declare this however you want.
            ImageList.Add(link.Attribute["src"].Value.ToString());
        }
    }
