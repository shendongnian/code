    private async Task ReadInputFile()
    {
        var collection = new ConcurrentBag<PropertyRecord>();
        var lines = System.IO.File.ReadLines(InputFileName);
        int i = 0;
        int RecordsCount = lines.Count();
        Parallel.ForEach(lines, line =>
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return;                    
            }
            var tokens = line.Split(',');
            var postalCode = tokens[0];
            var country = tokens.Length > 1 ? tokens[1] : "england";
                
            SetLabelNotifyTwoText(
                string.Format(
                    "Reading PostCode {0} out of {1}"
                    i,
                    lines.Length));
            
            var tempRecord = await GetAllAddesses(postalCode, country);
            if (tempRecord != null)
            {
                foreach (PropertyRecord r in tempRecord)
                {
                    collection.Add(r);
                }
            }    
        });
    }
    private async Task<List<PropertyRecord>> GetAllAddesses(
            string postalCode,
            string country = "england")
    {
        SetLabelNotifyText("");
        progressBar1.Value = 0;
        progressBar1.Update();
        var records = new List<PropertyRecord>();
        using (WebClient w = new WebClient())
        {
            var url = CreateUrl(postalCode, country);
            var document = await w.DownloadStringTaskAsync(url);
            var pagesCount = GetPagesCount(document);
            if (pagesCount == null)
            {
                return null;
            }
            
            for (int i = 0; i < pagesCount; i++)
            {
                SetLabelNotifyText(
                    string.Format(
                        "Reading Page {0} out of {1}",
                        i,
                        pagesCount - 1));
                url = CreateUrl(postalcode,country, i);
                document = await w.DownloadStringTaskAsync(url);
                var collection = Regex.Matches(
                    document,
                    "<div class=\"soldDetails\">(.|\\n|\\r)*?class=" +
                    "\"soldAddress\".*?>(?<address>.*?)(</a>|</div>)" +
                    "(.|\\n|\\r)*?class=\\\"noBed\\\">(?<noBed>.*?)" +
                    "</td>|</tbody>");
                foreach (var match in collection)
                {
                    var r = new PropertyRecord();
                    
                    var bedroomCount = match.Groups["noBed"].Value;
                    if(!string.IsNullOrEmpty(bedroomCount))
                    {
                        r.BedroomCount = bedroomCount;             
                    }
                    else
                    {
                        r.BedroomCount = "-1";
                    }
                    r.address = match.Groups["address"].Value;
                    var line = string.Format(
                        "\"{0}\",{1}",
                        r.address
                        r.BedroomCount);
                    OutputLines.Add(line);
                    Records.Add(r);
                }
            }
        }
    
        return Records;
    }
