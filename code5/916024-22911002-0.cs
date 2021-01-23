            var reader = XmlReader.Create("http://www.journaldunet.com/web-tech/rss/");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            foreach (SyndicationItem item in feed.Items)
            {
                string description = item.Summary.Text;
                var images = GetImgUrlsFromString(description);
            }
        }
        List<string> GetImgUrlsFromString(string html)
        {
            List<string> imageList = new List<string>();
            var images = html.Split(new string[] { "<img" }, StringSplitOptions.None);
            foreach (string image in images)
            {
                var srcIndex = image.IndexOf(" src=\"");
                if (srcIndex > -1)
                {
                    srcIndex += 6;
                    var srcEndIndex = image.IndexOf("\"", srcIndex) + 1;
                    string imgSrcUrl = image.Substring(srcIndex, srcEndIndex - srcIndex);
                    imageList.Add(imgSrcUrl);
                }
            }
            return imageList;
        }
