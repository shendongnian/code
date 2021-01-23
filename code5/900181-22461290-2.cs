    private void GetYoutubePlaylist(string feedXML)
            {
             var last = new YoutubeVideo(); //scroll to this item when new items are loaded
            if(videosList.Count > max_results)
                last = videosList[videosList.Count - 11];
            try
            {
                StringReader stringReader = new StringReader(feedXML);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
                
                YoutubeVideo video;
                foreach (SyndicationItem item in feed.Items)
                {
                    video = new YoutubeVideo();
                    video.YoutubeLink = item.Links[0].Uri;
                    string a = video.YoutubeLink.ToString().Remove(0, 31);
                    video.Id = a.Substring(0, 11);
                    video.Title = item.Title.Text;
                    video.PubDate = item.PublishDate.DateTime;
                    video.Thumbnail = YouTube.GetThumbnailUri(video.Id, YouTubeThumbnailSize.Small);
                    videosList.Add(video);
                }
                
                MainListBox.ItemsSource = null;
                MainListBox.ItemsSource = videosList;
                if(last.Id!=null)
                MainListBox.ScrollTo(last as YoutubeVideo);
            }
            catch {            }
        }
