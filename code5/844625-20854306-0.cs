    // download the site content and create a new html document
    // NOTE: make this asynchronous etc when considering IO performance
    var url = "http://explorer.litecoin.net/address/Li7x5UZqWUy7o1tEC2x5o6cNsn2bmDxA2N";
    var data = new WebClient().DownloadString(url);
    var doc = new HtmlDocument();
    doc.LoadHtml(data);
    
    // extract the transactions 'h3' title, the node we want is directly before it
    var transTitle = 
    	(from h3 in doc.DocumentNode.Descendants("h3")
    	 where h3.InnerText.ToLower() == "transactions"
    	 select h3).FirstOrDefault();
    
    // tokenise the summary, one line per 'br' element, split each line by the ':' symbol
    var summary = transTitle.PreviousSibling.PreviousSibling;
    var tokens = 
    	(from row in summary.InnerHtml.Replace("<br>", "|").Split('|')
    	 where !string.IsNullOrEmpty(row.Trim())
    	 let line = row.Trim().Split(':')
    	 where line.Length == 2
    	 select new { name = line[0].Trim(), value = line[1].Trim() });
    
    // using linqpad to debug, the dump command drops the currect variable to the output
    tokens.Dump();
