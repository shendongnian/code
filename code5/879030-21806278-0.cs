	var client = new System.Net.WebClient();
	
	client.Encoding = System.Text.Encoding.GetEncoding(1255);
	
	var page = client.DownloadString("http://rotter.net/scoopscache.html");
	
	var re = new Regex(@"<span style=color:#000099;>(.+?)</span>");
	
	var matches = re.Matches(page)
                    .Cast<Match>()
                    .Select(_ => _.Groups[1].Value)
                    .ToArray();
    /*
        'matches' contains the matched strings 
    */
