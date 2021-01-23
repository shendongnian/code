      if (count <= 200) {
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText200 + yahooParameters;
                csvData200 = web.DownloadString(Url);
            }
            csvData = csvData200;
            List<Price> prices = Parse(csvData);
            GridView1.DataSource = prices;
            GridView1.DataBind();
        }
        if (count>=201 & count<=400)
        {
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText200 + yahooParameters;
                csvData200 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText400 + yahooParameters;
                csvData400 = web.DownloadString(Url);
            }
            csvData = csvData200 + csvData400;
            List<Price> prices = Parse(csvData);
            GridView1.DataSource = prices;
            GridView1.DataBind();
        }
        if (count >= 401 & count <= 600)
        {
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText200 + yahooParameters;
                csvData200 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText400 + yahooParameters;
                csvData400 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText600 + yahooParameters;
                csvData600 = web.DownloadString(Url);
            }
            csvData = csvData200 + csvData400 + csvData600;
            List<Price> prices = Parse(csvData);
            GridView1.DataSource = prices;
            GridView1.DataBind();
        }
        if (count >= 601 & count <= 800)
        {
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText200 + yahooParameters;
                csvData200 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText400 + yahooParameters;
                csvData400 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText600 + yahooParameters;
                csvData600 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText800 + yahooParameters;
                csvData800 = web.DownloadString(Url);
            }
            csvData = csvData200 + csvData400 + csvData600 + csvData800;
            List<Price> prices = Parse(csvData);
            GridView1.DataSource = prices;
            GridView1.DataBind();
        }
        if (count >= 801 & count <= 1000)
        {
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText200 + yahooParameters;
                csvData200 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText400 + yahooParameters;
                csvData400 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText600 + yahooParameters;
                csvData600 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText800 + yahooParameters;
                csvData800 = web.DownloadString(Url);
            }
            using (WebClient web = new WebClient())
            {
                Url = yahooQuoteUrl + cellText1000 + yahooParameters;
                csvData1000 = web.DownloadString(Url);
            }
            csvData = csvData200 + csvData400 + csvData600 + csvData800 + csvData1000;
            List<Price> prices = Parse(csvData);
            GridView1.DataSource = prices;
            GridView1.DataBind();
        }
